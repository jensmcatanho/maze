using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Core {

public class EventManager : MonoBehaviour {
    public bool LimitQueueProcesing = false;
    public float QueueProcessTime = 0.0f;
    static EventManager s_Instance = null;
    Queue m_eventQueue = new Queue();

    public delegate void EventDelegate<T> (T e) where T : Events.GameEvent;
    delegate void EventDelegate (Events.GameEvent e);

    Dictionary<System.Type, EventDelegate> delegates = new Dictionary<System.Type, EventDelegate>();
    Dictionary<System.Delegate, EventDelegate> delegateLookup = new Dictionary<System.Delegate, EventDelegate>();
    Dictionary<System.Delegate, System.Delegate> onceLookups = new Dictionary<System.Delegate, System.Delegate>();

    public static EventManager Instance {
        get {
            if (s_Instance == null) {
                s_Instance = GameObject.FindObjectOfType (typeof(EventManager)) as EventManager;
            }

            return s_Instance;
        }
    }
    
    EventDelegate AddDelegate<T>(EventDelegate<T> del) where T : Events.GameEvent {
        // Early-out if we've already registered this delegate
        if (delegateLookup.ContainsKey(del))
            return null;

        // Create a new non-generic delegate which calls our generic one.
        // This is the delegate we actually invoke.
        EventDelegate internalDelegate = (e) => del((T)e);
        delegateLookup[del] = internalDelegate;

        EventDelegate tempDel;
        if (delegates.TryGetValue(typeof(T), out tempDel)) {
            delegates[typeof(T)] = tempDel += internalDelegate; 
        } else {
            delegates[typeof(T)] = internalDelegate;
        }

        return internalDelegate;
    }

    public void AddListener<T> (EventDelegate<T> del) where T : Events.GameEvent {
        AddDelegate<T>(del);
    }

    public void AddListenerOnce<T> (EventDelegate<T> del) where T : Events.GameEvent {
        EventDelegate result = AddDelegate<T>(del);

        if (result != null) {
            onceLookups[result] = del;
        }
    }

    public void RemoveListener<T> (EventDelegate<T> del) where T : Events.GameEvent {
        EventDelegate internalDelegate;
        if (delegateLookup.TryGetValue(del, out internalDelegate)) {
            EventDelegate tempDel;

            if (delegates.TryGetValue(typeof(T), out tempDel)) {
                tempDel -= internalDelegate;

                if (tempDel == null) {
                    delegates.Remove(typeof(T));
                } else {
                    delegates[typeof(T)] = tempDel;
                }
            }

            delegateLookup.Remove(del);
        }
    }

    public void RemoveAll(){
        delegates.Clear();
        delegateLookup.Clear();
        onceLookups.Clear();
    }

    public bool HasListener<T> (EventDelegate<T> del) where T : Events.GameEvent {
        return delegateLookup.ContainsKey(del);
    }

    public void TriggerEvent (Events.GameEvent e) {
        EventDelegate del;

#if UNITY_EDITOR
        Debug.Log("Event " + e.ToString() + " triggered.");
#endif

        if (delegates.TryGetValue(e.GetType(), out del)) {
            del.Invoke(e);
#if UNITY_EDITOR
        Debug.Log("Listener " + del.Target.ToString().Split('[', ']')[1] + " invoked.");
#endif

            // remove listeners which should only be called once
            foreach (EventDelegate k in delegates[e.GetType()].GetInvocationList()) {
                if (onceLookups.ContainsKey(k)) {
                    delegates[e.GetType()] -= k;

                    if (delegates[e.GetType()] == null) {
                        delegates.Remove(e.GetType());
                    }

                    delegateLookup.Remove(onceLookups[k]);
                    onceLookups.Remove(k);
                }
            }
            
        } else {
            Debug.LogWarning("Event: " + e.GetType() + " has no listeners");
        }
    }

    //Inserts the event into the current queue.
    public bool QueueEvent(Events.GameEvent evt) {
        if (!delegates.ContainsKey(evt.GetType())) {
            Debug.LogWarning("EventManager: QueueEvent failed due to no listeners for event: " + evt.GetType());
            return false;
        }

        m_eventQueue.Enqueue(evt);
        return true;
    }

    //Every update cycle the queue is processed, if the queue processing is limited,
    //a maximum processing time per update can be set after which the events will have
    //to be processed next update loop.
    void Update() {
        float timer = 0.0f;
        while (m_eventQueue.Count > 0) {
            if (LimitQueueProcesing) {
                if (timer > QueueProcessTime)
                    return;
            }

            Events.GameEvent evt = m_eventQueue.Dequeue() as Events.GameEvent;
            TriggerEvent(evt);

            if (LimitQueueProcesing)
                timer += Time.deltaTime;
        }
    }

    public void OnApplicationQuit(){
        RemoveAll();
        m_eventQueue.Clear();
        s_Instance = null;
    }
}

}
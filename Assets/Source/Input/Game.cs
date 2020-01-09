using UnityEngine;
using UnityEngine.UI;

namespace Input {

public class Game : MonoBehaviour, Core.IEventListener {
    bool isPlaying = false;

    public void CreateListeners() {
        Core.EventManager.Instance.AddListener<Core.Events.GameStarted>(StartGameplay);
        Core.EventManager.Instance.AddListener<Events.PauseButtonPressed>(Pause);
        Core.EventManager.Instance.AddListener<Events.ResumeGameButtonPressed>(Resume);
    }

    void Awake() {
        CreateListeners();
    }

    void Update() {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Escape) && isPlaying)
            Core.EventManager.Instance.QueueEvent(new Events.PauseButtonPressed());
    }

    void StartGameplay(Core.Events.GameStarted e) {
        isPlaying = true;
    }

    void Pause(Events.PauseButtonPressed e) {
        isPlaying = false;
    }

    void Resume(Events.ResumeGameButtonPressed e) {
        isPlaying = true;
    }
}

namespace Events {

public class PauseButtonPressed : Core.Events.GameEvent {
    public PauseButtonPressed() {
        Debug.Log("Event :: Input :: PauseButtonPressed");
    }
}

}

}

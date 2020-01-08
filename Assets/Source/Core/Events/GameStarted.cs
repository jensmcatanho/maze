using UnityEngine;

namespace Core {

namespace Events {

public class GameStarted : Core.Events.GameEvent {
    public GameStarted() {
        Debug.Log("Event :: GameStarted");
    }
}

}

}
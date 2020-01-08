using UnityEngine;

namespace Input {

namespace Events {

public class PauseGame : Core.Events.GameEvent {
    public PauseGame() {
        Debug.Log("Event :: PauseGame");
    }
}

}

}
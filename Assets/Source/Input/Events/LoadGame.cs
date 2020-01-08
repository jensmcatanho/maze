using UnityEngine;

namespace Input {

namespace Events {

public class LoadGame : Core.Events.GameEvent {
    public Core.GameplaySettings gameSettings { get; private set; }

    public LoadGame(Core.GameplaySettings gs) {
        Debug.Log("Event :: LoadGame");
        gameSettings = gs;
    }
    
}

}

}
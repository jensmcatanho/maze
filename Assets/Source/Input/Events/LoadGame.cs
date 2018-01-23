namespace Input {

namespace Events {

public class LoadGame : Core.Events.GameEvent {
    public Core.GameplaySettings gameSettings { get; private set; }

    public LoadGame(Core.GameplaySettings gs) { gameSettings = gs; }
    
}

}

}
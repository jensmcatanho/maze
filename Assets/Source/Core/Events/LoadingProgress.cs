namespace Core {

namespace Events {

public class LoadingProgress : GameEvent {
    public float progress { get; private set; }

    public LoadingProgress(float p) { progress = p; }
}

}

}
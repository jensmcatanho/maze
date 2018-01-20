
namespace Gameplay {

namespace Events {

public class MazeReady<T> : Core.Events.GameEvent {
    public Maze<T> maze {
        get;
        private set;
    }

    public MazeReady(Maze<T> m) {
        maze = m;
    }
}

}

}
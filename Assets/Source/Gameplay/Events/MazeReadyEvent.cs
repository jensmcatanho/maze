
namespace Gameplay {

namespace Events {

public class MazeReady<T> : Core.Events.GameEvent {
    public Maze<T> m_Maze { get; private set; }

    public MazeReady(Maze<T> m) { m_Maze = m; }
}

}

}

namespace Gameplay {

namespace Events {

public class MazeReady : Core.Events.GameEvent {
    public Maze<Cell> m_Maze { get; private set; }

    public MazeReady(Maze<Cell> m) { m_Maze = m; }
}

}

}
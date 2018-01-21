
namespace Rendering {

namespace Events {

public class MazeReady : Core.Events.GameEvent {
    public Maze maze { get; private set; }

    public MazeReady(Maze m) { maze = m; }
}

}

}
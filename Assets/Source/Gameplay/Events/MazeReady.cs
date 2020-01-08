using UnityEngine;

namespace Gameplay {

namespace Events {

public class MazeReady : Core.Events.GameEvent {
    public Maze<Cell> m_Maze { get; private set; }

    public MazeReady(Maze<Cell> m) { 
        Debug.Log("Event :: MazeReady");
        m_Maze = m;
    }
}

}

}
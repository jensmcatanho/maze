using UnityEngine;

namespace Gameplay {

public class GameplaySystem : MonoBehaviour, Core.IEventListener {
    static GameplaySystem s_Instance = null;

    public static GameplaySystem Instance {
        get {
            if (s_Instance == null) {
                s_Instance = GameObject.FindObjectOfType (typeof(GameplaySystem)) as GameplaySystem;
            }
            
            return s_Instance;
        }
    }

    public void CreateListeners() {
		Core.EventManager.Instance.AddListener<Core.Events.GameSceneLoaded>(CreateMaze);
    }

    void Awake() {
        CreateListeners();
    }

    public void CreateMaze(Core.Events.GameSceneLoaded e) {
        switch (e.mazeType) {
            case Core.MazeType.DFS:
                DFSFactory dfsFactory = new DFSFactory();
                dfsFactory.CreateMaze(e.mazeLength, e.mazeWidth, e.cellSize);
                break;
            case Core.MazeType.Prim:
                PrimFactory primFactory = new PrimFactory();
                primFactory.CreateMaze(e.mazeLength, e.mazeWidth, e.cellSize);
                break;
        }
    }
}

}
using UnityEngine;

namespace Gameplay {

public class GameplaySystem : MonoBehaviour {
    static GameplaySystem s_Instance = null;

    DFSFactory mazeFactory;

    public void CreateListeners() {
		EventManager.Instance.AddListener<global::Events.CreateNewMaze>(CreateMaze);
    }

    void Awake() {
        CreateListeners();
        s_Instance = null;
        
    }

    public static GameplaySystem Instance {
        get {
            if (s_Instance == null) {
                s_Instance = GameObject.FindObjectOfType (typeof(GameplaySystem)) as GameplaySystem;
            }
            return s_Instance;
        }
    }

    void CreateMaze(global::Events.CreateNewMaze e) {
        switch (e.mazeType) {
            case MazeType.DFS:
                mazeFactory = new DFSFactory();
                break;
            case MazeType.Prim:
                //mazeFactory = new PrimFactory();
                break;
        }

        mazeFactory.CreateMaze(e.mazeLength, e.mazeWidth, e.cellSize);
    }
}

}
using UnityEngine;

namespace Rendering {

public class RenderingSystem : MonoBehaviour, Core.IEventListener {
    static RenderingSystem s_Instance = null;

    MazeFactory mazeFactory;

    public void CreateListeners() {
		Core.EventManager.Instance.AddListener<Gameplay.Events.MazeReady<Gameplay.DFSCell>>(CreateMaze);
    }

    void Awake() {
        CreateListeners();
        s_Instance = null;   
    }

    public static RenderingSystem Instance {
        get {
            if (s_Instance == null) {
                s_Instance = GameObject.FindObjectOfType (typeof(RenderingSystem)) as RenderingSystem;
            }
            return s_Instance;
        }
    }

    void CreateMaze(Gameplay.Events.MazeReady<Gameplay.DFSCell> e) {
		mazeFactory = GameObject.Find("RenderingSystem").GetComponent<MazeFactory>();
        mazeFactory.CreateMaze(e.maze);
#if UNITY_EDITOR
        ASCIIFactory.Render(e.maze, "x");
#endif
    }
}

}
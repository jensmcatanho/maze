using UnityEngine;

namespace Rendering {

public class RenderingSystem : MonoBehaviour, Core.IEventListener {
    static RenderingSystem s_Instance = null;

    MazeFactory mazeFactory;

    public static RenderingSystem Instance {
        get {
            if (s_Instance == null) {
                s_Instance = GameObject.FindObjectOfType (typeof(RenderingSystem)) as RenderingSystem;
            }
            
            return s_Instance;
        }
    }

    public void CreateListeners() {
		Core.EventManager.Instance.AddListener<Gameplay.Events.MazeReady>(CreateMaze);
    }

    void Awake() {
        CreateListeners();
        s_Instance = null;   
    }

    void CreateMaze(Gameplay.Events.MazeReady e) {
		mazeFactory = GameObject.Find("RenderingSystem").GetComponent<MazeFactory>();
        mazeFactory.CreateMaze(e.m_Maze);
#if UNITY_EDITOR
        ASCIIFactory.Render(e.m_Maze, "x");
#endif
    }
}

}
using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public enum MazeType {
	DFS,
	Prim
}

public class MainSystem : MonoBehaviour, IEventListener {
	[SerializeField]
	GameObject player;

	[SerializeField]
	 int mazeLength;

	[SerializeField]
	int mazeWidth;
	
	[SerializeField]
	int cellSize;

	[SerializeField]
	string asciiDisplay;

	Rendering.MazeFactory mazeFactory;

	// Subsystems
	EventManager eventManager;
	Gameplay.GameplaySystem gameplaySystem;

	public void CreateListeners() {
		eventManager.AddListener<Rendering.Events.MazeReady>(CreatePlayer);
	}

	void Awake() {
		// Subsystems
		gameplaySystem = Gameplay.GameplaySystem.Instance;
		eventManager = EventManager.Instance;

		CreateListeners();

		EventManager.Instance.QueueEvent(new Events.CreateNewMaze(MazeType.DFS, mazeLength, mazeWidth, cellSize));
	}

	void Start () {
        // Gameplay.Maze<Gameplay.DFSCell> gpMaze = dfsFactory.CreateMaze(mazeLength, mazeWidth, cellSize);
		// Rendering.ASCIIRenderer.Render(gpMaze, asciiDisplay);
	}

	void CreatePlayer(Rendering.Events.MazeReady e) {
		Instantiate (player, new Vector3 (1.0f * cellSize, 1.0f, 1.0f * cellSize), new Quaternion());
	}
}

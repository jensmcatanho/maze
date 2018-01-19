using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class GameManager : MonoBehaviour, IEventListener {
	[SerializeField]
	GameObject player;

	[SerializeField]
	 int mazeLength;

	[SerializeField]
	int mazeWidth;
	
	[SerializeField]
	int cellSize;

	Gameplay.DFSFactory dfsFactory;
	Rendering.MazeFactory mazeFactory;

	void Awake() {
		CreateListeners();

		dfsFactory = new Gameplay.DFSFactory();
		mazeFactory = GameObject.Find("GameManager").GetComponent<Rendering.MazeFactory>();
	}

	void Start () {
        Gameplay.Maze<Gameplay.DFSCell> gpMaze = dfsFactory.CreateMaze(mazeLength, mazeWidth, cellSize);
		Rendering.ASCIIRenderer.Render(gpMaze, "x");
	}

	public void CreateListeners() {
		EventManager.Instance.AddListener<Rendering.Events.MazeReady>(CreatePlayer);
	}

	void CreatePlayer(Rendering.Events.MazeReady e) {
		Instantiate (player, new Vector3 (1.0f * cellSize, 1.0f, 1.0f * cellSize), new Quaternion());
	}
}

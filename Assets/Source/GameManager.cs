using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class GameManager : MonoBehaviour {
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
		dfsFactory = new Gameplay.DFSFactory();
		mazeFactory = GameObject.Find("GameManager").GetComponent<Rendering.MazeFactory>();
	}

	void Start () {
        Gameplay.Maze<Gameplay.DFSCell> gpMaze = dfsFactory.CreateMaze(mazeLength, mazeWidth, cellSize);

		Instantiate (player, new Vector3 (1.0f * cellSize, 1.0f, 1.0f * cellSize), new Quaternion());
		Rendering.ASCIIRenderer.Render(gpMaze, "x");

	}
}

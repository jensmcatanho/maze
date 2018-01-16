using UnityEngine;
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

	Gameplay.DFSFactory dfsFactory = new Gameplay.DFSFactory();
	Rendering.MazeFactory mazeFactory;

	void Start () {
        mazeFactory = GameObject.Find("GameManager").GetComponent<Rendering.MazeFactory>();
        Gameplay.Maze<Gameplay.DFSCell> gpMaze = dfsFactory.CreateMaze(mazeLength, mazeWidth, cellSize);
        Rendering.Maze maze = mazeFactory.CreateMaze(gpMaze);

		Instantiate (player, new Vector3 (1.0f * cellSize, 1.0f, 1.0f * cellSize), new Quaternion());
		Rendering.ASCIIRenderer.Render(gpMaze, "x");
	}
}

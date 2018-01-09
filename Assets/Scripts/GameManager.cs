using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject player;
	public GameObject finishTrigger;

	public Gameplay.MazeFactory dfsFactory = new Gameplay.PrimFactory();
	Rendering.MazeFactory mazeFactory;

	void Start () {
        mazeFactory = GameObject.Find("GameManager").GetComponent<Rendering.MazeFactory>();
        Gameplay.Maze gpMaze = dfsFactory.CreateMaze(10, 10, 2);
        Rendering.Maze maze = mazeFactory.CreateMaze(gpMaze);

		Instantiate (player, new Vector3 (1.0f * gpMaze.cellSize, 1.0f, 1.0f * gpMaze.cellSize), new Quaternion());
		Instantiate (finishTrigger, new Vector3 ((2 * gpMaze.Length - 1) * gpMaze.cellSize, 1.0f, (2 * gpMaze.Width + 2) * gpMaze.cellSize), new Quaternion ());
	}
	/*public Maze mainMaze;

	public GameObject player;
	public GameObject finishTrigger;
	public GameObject chest;

	public int mazeLength;
	public int mazeWidth;

	void Start () {		
		mainMaze.Init (mazeLength, mazeWidth);

		mainMaze.spawnPoint = new Vector3 (1.0f * mainMaze.cellSize, 1.0f, 1.0f * mainMaze.cellSize);
		mainMaze.finishPoint = new Vector3 ((2 * mazeLength - 1) * mainMaze.cellSize, 1.0f, (2 * mazeWidth + 2) * mainMaze.cellSize);

		Instantiate (player, mainMaze.spawnPoint, new Quaternion());
		Instantiate (finishTrigger, mainMaze.finishPoint, new Quaternion ());

		mainMaze.Setup ();

	
	}*/
	
	/*
	public GameObject player;
	public GameObject finishTrigger;

	public Gameplay.DFSFactory mf = new Gameplay.DFSFactory();
	public Gameplay.Maze testMaze;
	//public Rendering.MazeFactory gmf = new Rendering.MazeFactory();
	public Rendering.Maze graphicMaze;

	void Start () {
		GameObject Labyrinth = new GameObject("Labyrinth");
		testMaze = mf.CreateMaze(10, 10, 1);
		Labyrinth.AddComponent<Rendering.MazeFactory>();
		graphicMaze = Labyrinth.GetComponent<Rendering.MazeFactory>().CreateMaze(testMaze);

		Vector3 spawnPoint = new Vector3 (1.0f * testMaze.cellSize, 1.0f, 1.0f * testMaze.cellSize);
		Vector3 finishPoint = new Vector3 ((2 * testMaze.Length - 1) * testMaze.cellSize, 1.0f, (2 * testMaze.Width + 2) * testMaze.cellSize);

		Instantiate (player, spawnPoint, new Quaternion());
		Instantiate (finishTrigger, finishPoint, new Quaternion ());
	} */
}

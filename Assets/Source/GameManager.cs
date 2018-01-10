﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject player;

	public int mazeLength;
	public int mazeWidth;
	public int cellSize;

	Gameplay.MazeFactory dfsFactory = new Gameplay.DFSFactory();
	Rendering.MazeFactory mazeFactory;

	void Start () {
        mazeFactory = GameObject.Find("GameManager").GetComponent<Rendering.MazeFactory>();
        Gameplay.Maze gpMaze = dfsFactory.CreateMaze(mazeLength, mazeWidth, cellSize);
        Rendering.Maze maze = mazeFactory.CreateMaze(gpMaze);

		Instantiate (player, new Vector3 (1.0f * cellSize, 1.0f, 1.0f * cellSize), new Quaternion());
		Rendering.ASCIIRenderer.Render(gpMaze, "x");
	}
}
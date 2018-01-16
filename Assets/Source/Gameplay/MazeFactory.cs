using UnityEngine;

namespace Gameplay {

public abstract class MazeFactory {
	protected Maze<Cell> maze;

	protected float pDeadEnd = 0;
	protected float pChest = 0;

	public Maze<Cell> CreateMaze(int length, int width, int cellSize) {
		maze = new Maze<Cell> (length, width, cellSize);

		for (int row = 0; row < length; row++)
			for (int col = 0; col < width; col++)
				maze[row, col] = new Cell (row, col, cellSize);

		CreatePath ();
		CreateChests ();

		return maze;
	}

	protected abstract void CreatePath ();

	protected abstract void ChestSetup ();

	void CreateChests () {
		ChestSetup ();
		
		for (int row = 0; row < maze.Length; row++)
			for (int col = 0; col < maze.Width; col++)
				if (CheckDeadEnd (row, col) && Random.value < pChest)
					maze [row, col].HasChest = true;
		
	}

	bool CheckDeadEnd(int row, int col) {
		int numWalls = 0;

		if (maze [row, col].HasWall (Wall.Left))
			numWalls++;
		
		if (maze [row, col].HasWall (Wall.Up))
			numWalls++;
		
		if (maze [row, col].HasWall (Wall.Right))
			numWalls++;
		
		if (maze [row, col].HasWall (Wall.Down))
			numWalls++;

		return numWalls == 3 ? true : false;
	}

}

}
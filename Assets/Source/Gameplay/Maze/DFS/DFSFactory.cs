using UnityEngine;
using System.Collections;

namespace Gameplay {

public class DFSFactory : MazeFactory {
	protected Maze<DFSCell> maze;

	public Maze<DFSCell> CreateMaze(int length, int width, int cellSize) {
		maze = new Maze<DFSCell> (length, width, cellSize);

		for (int row = 0; row < length; row++)
			for (int col = 0; col < width; col++)
				maze[row, col] = new DFSCell (row, col, cellSize);

		CreatePath ();
		CreateChests ();

		Core.EventManager.Instance.QueueEvent(new Events.MazeReady<DFSCell>(maze));
		return maze;
	}

	protected override void CreatePath () {
		ArrayList history = new ArrayList ();
		ArrayList neighbors = new ArrayList ();

		int length = maze.Length;
		int width = maze.Width;

		// 1. Start in the first cell.
		int row = 0;
		int col = 0;

		// 2. Add it to the history stack.
		history.Add (new Vector2 (row, col));

		while (history.Count > 0) {
			// 3. Mark it as visited.
			maze[row, col].m_Status = DFSCell.Status.Visited;
            
			// 4. Check which of its neighbors were not yet visited.
			neighbors.Clear();
			if (col > 0 && maze [row, col - 1].m_Status == DFSCell.Status.None)
				neighbors.Add ('L');

			if (row > 0 && maze [row - 1, col].m_Status == DFSCell.Status.None)
				neighbors.Add ('U');

			if (col < length - 1 && maze [row, col + 1].m_Status == DFSCell.Status.None)
				neighbors.Add ('R');

			if (row < width - 1 && maze [row + 1, col].m_Status == DFSCell.Status.None)
				neighbors.Add ('D');
            
			// 5a. If there is a neighbor not yet visited, choose one randomly to connect to the current cell. 
			if (neighbors.Count > 0) {
				history.Add (new Vector2 (row, col));
				char direction = System.Convert.ToChar (neighbors [Random.Range (0, neighbors.Count)]);

				switch (direction) {
				case 'L':
					maze [row, col].ToggleWall(Wall.Left);
					maze [row, --col].ToggleWall(Wall.Right);
					break;

				case 'U':
					maze [row, col].ToggleWall(Wall.Up);
					maze [--row, col].ToggleWall(Wall.Down);
					break;

				case 'R':
					maze [row, col].ToggleWall(Wall.Right);
					maze [row, ++col].ToggleWall(Wall.Left);
					break;

				case 'D':
					maze [row, col].ToggleWall(Wall.Down);
					maze [++row, col].ToggleWall(Wall.Up);
					break;

				}

				// 5b. If there isn't a neighbor to visit, backtrack one step.
			} else {
				Vector2 retrace = (Vector2)history [history.Count - 1];
				row = (int)retrace.x;
				col = (int)retrace.y;

				history.RemoveAt (history.Count - 1);
			}
			// 6. If there are still cells in the history list, go back to step 3.
		}

		// 7. Open an entrance and a exit to the maze.
		maze.Entrance = maze [0, 0];
		maze.Entrance.SetType(Cell.Type.Entrance);
		maze [0, 0].ToggleWall (Wall.Left);

		Vector2 exitPosition = new Vector2(Random.Range(length * 0.5f, length), Random.Range(width * 0.5f, width));
		if (exitPosition.x > exitPosition.y) {
			exitPosition.y = width - 1;
			maze [(int)exitPosition.x, (int)exitPosition.y].ToggleWall (Wall.Right); 
		} else {
			exitPosition.x = length - 1;
			maze [(int)exitPosition.x, (int)exitPosition.y].ToggleWall (Wall.Down); 
		}

		maze.Exit = maze [(int)exitPosition.x, (int)exitPosition.y];
		maze.Exit.SetType (Cell.Type.Exit);
	}

	protected override void ChestSetup () {
		/*  Equation 1: nC = (l * w) * dE * pC
		 *  Equation 2: nC = (l * w) * 0.05
		 * 
		 *  (l * w) * 0.05 = (l * w) * dE * pC =>
		 *  dE * pC = 0.05
		 * 
		 *  l = maze's length
		 *  w = maze's width
		 *  nC = maximum number of chests
		 *  dE = percentage of dead ends
		 *  pC = probability of chest spawning
		 * 
		 */
	
		// pChest = 0.05 / pDeadEnd
		pDeadEnd = 0.1f;
		pChest = 0.5f;
	}

	protected override void CreateChests () {
		ChestSetup ();
		
		for (int row = 0; row < maze.Length; row++)
			for (int col = 0; col < maze.Width; col++)
				if (CheckDeadEnd (row, col) && Random.value < pChest)
					maze [row, col].HasChest = true;
		
	}

	protected override bool CheckDeadEnd(int row, int col) {
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
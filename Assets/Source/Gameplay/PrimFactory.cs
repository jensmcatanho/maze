using UnityEngine;
using System.Collections;

namespace Gameplay {

public class PrimFactory : MazeFactory {

	protected override void CreatePath () {
		System.Diagnostics.Debug.Assert(!maze[0, 0].HasWall(Wall.None));

		int length = maze.Length;
		int width = maze.Width;

		ArrayList frontier = new ArrayList ();
		ArrayList neighbors = new ArrayList ();

		// 1. Pick a cell randomly.
		int row = Random.Range (0, length);
		int col = Random.Range (0, width);

		// 2. Mark it as visited.
		maze[row, col].Status = Status.Visited;

		do {
			// 3. Add its neighbors to the frontier list and mark them as part of the frontier.
			if (col > 0 && maze [row, col - 1].Status == Status.None) {
				frontier.Add (new Vector2 (row, col - 1)); // Left
				maze [row, col - 1].Status = Status.Neighbor;
			}

			if (row > 0 && maze [row - 1, col]. Status == Status.None) {
				frontier.Add (new Vector2 (row - 1, col)); // Up
				maze [row - 1, col].Status = Status.Neighbor;
			}

			if (col < length - 1 && maze [row, col + 1].Status == Status.None) {
				frontier.Add (new Vector2 (row, col + 1)); // Right
				maze [row, col + 1].Status = Status.Neighbor;
			}

			if (row < width - 1 && maze [row + 1, col].Status == Status.None) {
				frontier.Add (new Vector2 (row + 1, col)); // Down
				maze [row + 1, col].Status = Status.Neighbor;
			}

			// 4. Pick a cell in the frontier list randomly.
			Vector2 nextCell = (Vector2)frontier [Random.Range (0, frontier.Count)];
			row = (int)nextCell.x; 
			col = (int)nextCell.y;

			// 5. Mark it as visited and remove it from the frontier list.
			frontier.Remove (nextCell);
			maze[row, col].Status = Status.Visited;

			// 6. Check which of its neighbors were already visited.
			neighbors.Clear();

			if (col > 0 && maze [row, col - 1].Status == Status.Visited)
				neighbors.Add('L');

			if (row > 0 && maze [row - 1, col].Status == Status.Visited)
				neighbors.Add('U');

			if (col < length - 1 && maze [row, col + 1].Status == Status.Visited)
				neighbors.Add('R');

			if (row < width - 1 && maze [row + 1, col].Status == Status.Visited)
				neighbors.Add('D');

			// 7. Randomly choose a neighbor to connect to the current cell.
			char direction = System.Convert.ToChar(neighbors[Random.Range(0, neighbors.Count)]);

			switch (direction) {
				case 'L':
					maze [row, col].ToggleWall(Wall.Left);
					maze [row, col - 1].ToggleWall(Wall.Right);
					break;
			
				case 'U':
					maze [row, col].ToggleWall(Wall.Up);
					maze [row - 1, col].ToggleWall(Wall.Down);
					break;

				case 'R':
					maze [row, col].ToggleWall(Wall.Right);
					maze [row, col + 1].ToggleWall(Wall.Left);
					break;

				case 'D':
					maze [row, col].ToggleWall(Wall.Down);
					maze [row + 1, col].ToggleWall(Wall.Up);
					break;

			}

			// 8. If there are still cells in the frontier list, go back to step 3.
		} while (frontier.Count > 0);

		// 9. Open an entrance and a exit to the maze.
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
		pDeadEnd = 0.36f;
		pChest = 0.14f;
	}

}

}
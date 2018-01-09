using UnityEngine;

namespace Rendering {

public class MazeFactory : MonoBehaviour {
	protected Maze mazeObject;

	// Prefabs
	public GameObject wallPrefab;
	public GameObject chestPrefab;

	public Maze CreateMaze(Gameplay.Maze maze) {
		mazeObject = new Maze ();
		CreateFloor(maze);
		
		// Create walls in the diagonal part of the maze.
		for (int i = 0; i < maze.Length; i++) {
			if (maze[i, i].HasWall(Gameplay.Wall.Left))
				CreateWall(maze, new Vector3 ((2 * i + 1) * maze.cellSize, 2.0f, 2 * i * maze.cellSize), new Vector3 (90.0f, 90.0f, 0.0f));

			if (maze[i, i].HasWall(Gameplay.Wall.Down))
				CreateWall (maze, new Vector3 ((2 * i + 2) * maze.cellSize, 2.0f, (2 * i + 1) * maze.cellSize), new Vector3 (90.0f, 0.0f, 0.0f));

			if (maze [i, i].HasWall(Gameplay.Wall.Up))
				CreateWall (maze, new Vector3 (2 * i * maze.cellSize, 2.0f, (2 * i + 1) * maze.cellSize), new Vector3 (90.0f, 0.0f, 180.0f));

			if (maze [i, i].HasWall(Gameplay.Wall.Right))
				CreateWall (maze, new Vector3 ((2 * i + 1) * maze.cellSize, 2.0f, (2 * i + 2) * maze.cellSize), new Vector3 (90.0f, -90.0f, 0.0f));
		}

		for (int i = 0; i < maze.Length; i++) {
			for (int j = i + 1; j < maze.Width; j++) {
				// Create walls and chests in the lower triangular part of the maze.
				if (maze[j, i].HasWall(Gameplay.Wall.Left))
					CreateWall(maze, new Vector3 ((2 * j + 1) * maze.cellSize, 2.0f, 2 * i * maze.cellSize), new Vector3(90.0f, 90.0f, 0.0f));

				if (maze[j, i].HasWall(Gameplay.Wall.Down))
					CreateWall (maze, new Vector3((2 * j + 2) * maze.cellSize, 2.0f, (2 * i + 1) * maze.cellSize), new Vector3(90.0f, 0.0f, 0.0f));

				if (maze[j, i].HasChest) {
					CreateChest(maze, j, i);
					mazeObject.NChests++;
				}
				
				// Create walls in the upper triangular part of the maze.
				if (maze [i, j].HasWall(Gameplay.Wall.Up))
					CreateWall (maze, new Vector3(2 * i * maze.cellSize, 2.0f, (2 * j + 1) * maze.cellSize), new Vector3(90.0f, 0.0f, 180.0f));

				if (maze [i, j].HasWall(Gameplay.Wall.Right))
					CreateWall (maze, new Vector3((2 * i + 1) * maze.cellSize, 2.0f, (2 * j + 2) * maze.cellSize), new Vector3(90.0f, -90.0f, 0.0f));

				if (maze[i, j].HasChest) {
					CreateChest(maze, i, j);
					mazeObject.NChests++;
				}

			}
		}

		return mazeObject;
	}

	void CreateFloor(Gameplay.Maze maze) {
		GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Plane);
	//	floor.transform.parent = mazeObject.m_Labyrinth.transform;
		floor.transform.localScale = new Vector3(maze.Length * 0.2f * maze.cellSize, 1, maze.Width * 0.2f * maze.cellSize);
		floor.transform.position = new Vector3 (maze.Length * maze.cellSize, 0, maze.Width * maze.cellSize);
	}

	void CreateWall(Gameplay.Maze maze, Vector3 position, Vector3 rotation) {
		Quaternion r = Quaternion.identity;
		r.eulerAngles = rotation;

		GameObject wall = Instantiate(wallPrefab, position, r) as GameObject;
		wall.transform.localScale *= maze.cellSize;
	}

	public void CreateChest(Gameplay.Maze maze, int row, int col) {
		Quaternion r = Quaternion.identity;
		Vector3 chestPosition = new Vector3 ((2 * row + 1) * maze.cellSize, 0.0f, (2 * col + 1) * maze.cellSize);
		Vector3 chestRotation = new Vector3();

		// Check which direction the chest is facing (which direction of the cell is open).
		switch (maze[row, col].DeadEndOpening()) {
		case Gameplay.Wall.Left:
			chestRotation = new Vector3 (0.0f, 180.0f, 0.0f);
			break;

		case Gameplay.Wall.Up:
			chestRotation = new Vector3 (0.0f, -90.0f, 0.0f);
			break;

		case Gameplay.Wall.Right:
			chestRotation = new Vector3 (0.0f, 0.0f, 0.0f);
			break;

		case Gameplay.Wall.Down:
			chestRotation = new Vector3 (0.0f, 90.0f, 0.0f);
			break;

		}

		r.eulerAngles = chestRotation;
		MonoBehaviour.Instantiate (chestPrefab, chestPosition, r);
	}
}

}
using System;
using System.IO;

namespace Rendering {

public class ASCIIRenderer {
	static public void Render(Gameplay.Maze maze, string display) {
		string [,]asciiMaze = new string[2 * maze.Length + 1, 2 * maze.Width + 1];

		for (int i = 0; i <= 2 * maze.Length; i++) {
			for (int j = 0; j <= 2 * maze.Width; j++) {
				if (i % 2 == 0 && j % 2 == 0) {
					asciiMaze[i, j] = display;

				} else {
					asciiMaze[i, j] = " ";
				}
			}
		}

		for (int i = 0; i < maze.Length; i++) {
			if (maze[i, i].HasWall(Gameplay.Wall.Left))
				asciiMaze[2 * i + 1, 2 * i] = display;

			if (maze[i, i].HasWall(Gameplay.Wall.Down))
				asciiMaze[2 * i + 2, 2 * i + 1] = display;

			if (maze [i, i].HasWall(Gameplay.Wall.Up))
				asciiMaze[2 * i, 2 * i + 1] = display;

			if (maze [i, i].HasWall(Gameplay.Wall.Right))
				asciiMaze[2 * i + 1, 2 * i + 2] = display;
		}

		for (int i = 0; i < maze.Length; i++) {
			for (int j = i + 1; j < maze.Width; j++) {
				if (maze[j, i].HasWall(Gameplay.Wall.Left))
					asciiMaze[2 * j + 1, 2 * i] = display;

				if (maze[j, i].HasWall(Gameplay.Wall.Down))
					asciiMaze[2 * j + 2, 2 * i + 1] = display;

				if (maze[j, i].HasChest)
					asciiMaze[2 * j + 1, 2 * i + 1] = "o";

				if (maze [i, j].HasWall(Gameplay.Wall.Up))
					asciiMaze[2 * i, 2 * j + 1] = display;

				if (maze [i, j].HasWall(Gameplay.Wall.Right))
					asciiMaze[2 * i + 1, 2 * j + 2] = display;

				if (maze[i, j].HasChest)
					asciiMaze[2 * i + 1, 2 * j + 1] = "o";
			}
		}

        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@Directory.GetCurrentDirectory() + "\\maze.txt")) {
			for (int i = 0; i < 2 * maze.Length + 1; i++) {
				string line = "";

				for (int j = 0; j < 2 * maze.Width + 1; j++)
					line += asciiMaze[i, j];
					
            	file.WriteLine(line);
			}
        }
	}
}

}
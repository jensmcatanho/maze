using Gameplay;
using System.Collections;

namespace Rendering {

public class ASCIIRenderer {
	static void Render(Gameplay.Maze maze) {
		ArrayList labyrinth = new ArrayList();

		// Initialize the types of rows.
		string evenRow = new string('x', maze.Length + 1);
		string oddRow = "";

		for (int i = 0; i < maze.Length + 1; i++)
			oddRow += i % 2 == 0 ? 'x' : ' ';
		
		
	}
}

}
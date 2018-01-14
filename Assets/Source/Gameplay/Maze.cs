namespace Gameplay {

[System.Serializable]
public class Maze {
	int m_Length;
	int m_Width;

	Cell[,] m_Cells;
	int m_CellSize;

	Cell m_Entrance;
	Cell m_Exit;

	// Maze constructor.
	public Maze(int length, int width, int cellSize) {
		InitializeMaze(length, width, cellSize);
	}

	// Helper function to initialize the matrix.
	void InitializeMaze(int length, int width, int cellSize) {
		m_Length = length;
		m_Width = width;
            
		m_Cells = new Cell[length, width];
		m_CellSize = cellSize;

		for (int row = 0; row < length; row++)
			for (int col = 0; col < width; col++)
				m_Cells [row, col] = new Cell (row, col, cellSize);
	}

	// Indexer for the cells in the maze.
	public Cell this[int row, int col] {
		get { return m_Cells [row, col]; }

		set { m_Cells[row, col] = value; }
	}

	public Cell Entrance {
		get { return m_Entrance; }

		set { m_Entrance = value; }
	}

	public Cell Exit {
		get { return m_Exit; }

		set { m_Exit = value; }
	}

	// Read-only accessors to the maze properties.
	public int Length { get { return m_Length; } }
	public int Width { get { return m_Width; } }
	public int cellSize { get { return m_Cells[0, 0].Size; } }

}

}
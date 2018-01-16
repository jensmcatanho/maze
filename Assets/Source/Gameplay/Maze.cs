namespace Gameplay {

[System.Serializable]
public class Maze<T> {
	int m_Length;
	int m_Width;

	T[,] m_Cells;
	int m_CellSize;

	T m_Entrance;
	T m_Exit;

	// Maze constructor.
	public Maze(int length, int width, int cellSize) {
		m_Length = length;
		m_Width = width;
		m_Cells = new T[length, width];
		m_CellSize = cellSize;
	//	InitializeMaze(length, width, cellSize);
	}

	// Helper function to initialize the matrix.
	void InitializeMaze(int length, int width, int cellSize) {
//		m_Length = length;
//		m_Width = width;
//          
//		m_Cells = new T[length, width];
//		m_CellSize = cellSize;

//		for (int row = 0; row < length; row++)
//			for (int col = 0; col < width; col++)
//				m_Cells [row, col] = new T (row, col, cellSize);
	}

	// Indexer for the cells in the maze.
	public T this[int row, int col] {
		get { return m_Cells [row, col]; }

		set { m_Cells[row, col] = value; }
	}

	public T Entrance {
		get { return m_Entrance; }

		set { m_Entrance = value; }
	}

	public T Exit {
		get { return m_Exit; }

		set { m_Exit = value; }
	}

	// Read-only accessors to the maze properties.
	public int Length { get { return m_Length; } }
	public int Width { get { return m_Width; } }
	public int CellSize { get { return m_CellSize; } }

}

}
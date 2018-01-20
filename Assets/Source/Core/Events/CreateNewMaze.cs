namespace Core {

namespace Events {

public class CreateNewMaze : GameEvent {
    public MazeType mazeType { get; private set; }

	public int mazeLength { get; private set; }

	public int mazeWidth { get; private set; }
	
	public int cellSize  { get; private set; }

    public CreateNewMaze(MazeType mType, int mLength, int mWidth, int cSize) {
        mazeType = mType;
        mazeLength = mLength;
        mazeWidth = mWidth;
        cellSize = cSize;
    }
}

}

}
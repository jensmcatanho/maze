namespace Core {

namespace Events {

public class CreateNewMaze : GameEvent {
    public MazeType mazeType { get; private set; }

	public int mazeLength { get; private set; }

	public int mazeWidth { get; private set; }
	
	public int cellSize  { get; private set; }

    public CreateNewMaze(GameplaySettings gpSettings) {
        mazeType = gpSettings.mazeType;
        mazeLength = gpSettings.mazeLength;
        mazeWidth = gpSettings.mazeWidth;
        cellSize = gpSettings.cellSize;
    }
}

}

}
﻿using UnityEngine;

namespace Gameplay {

public abstract class MazeFactory {
	protected float pDeadEnd = 0;
	protected float pChest = 0;

	protected abstract void CreatePath ();

	protected abstract void ChestSetup ();

	protected abstract void CreateChests ();

	protected abstract bool CheckDeadEnd(int row, int col);

}

}
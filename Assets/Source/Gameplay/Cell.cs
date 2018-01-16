using UnityEngine;
using System.Collections;

namespace Gameplay {

// Flags which walls exist around the cell.
[System.Flags]
public enum Wall {
	None  =      0,
	Left  = 1 << 0,
	Up    = 1 << 1,
	Right = 1 << 2,
	Down  = 1 << 3

}

// Flags if the cell was already visited by an algorithm or if it's nearby a visited cell.
public enum Status {
	None     = 0,
	Visited  = 1,
	Neighbor = 2
}

public class Cell {
	// Flags if the cell is an entrance, an exit or none.
	[System.Flags]
	public enum Type {
		None     =      0,
		Entrance = 1 << 0,
		Exit     = 1 << 1

	}

	int m_Size;
	bool m_HasChest;

	Status m_Status;
	Wall m_Walls;
	Type m_Type;

	Vector2 m_Position;

	public Cell(int x, int y, int size) {
		m_Position = new Vector2(x, y);
		m_Size = size;

		SetWall (Wall.Left);
		SetWall (Wall.Up);
		SetWall (Wall.Right);
		SetWall (Wall.Down);
	}

	public Vector2 Position {
		get { return m_Position; }
		set { m_Position = value; }
	}

	public int Size {
		get { return m_Size; }
	}

	public Status Status {
		get { return m_Status; }
		set { m_Status = value; }
	}

	public bool HasChest {
		get { return m_HasChest; }
		set { m_HasChest = value; }
	}

	public void SetWall(Wall target) {
		/* eg. Setting left wall.
		 *   0 0 0 0 m_Walls
		 * | 0 0 0 1 target
		 * -----------------
		 *   0 0 0 1 m_Walls
		 */
		m_Walls = m_Walls | target;
	}

	public void UnsetWall(Wall target) {
		/* eg. Unsetting left wall.
		 *   1 1 1 1 m_Walls
		 * & 1 1 1 0 ~target
		 * -----------------
		 *   1 1 1 0 m_Walls
		 */
		m_Walls = m_Walls & (~target);
	}

	public void ToggleWall(Wall target) {
		/* eg. Toggle left wall.
		 *   0 0 0 1 m_Walls
		 * ^ 0 0 0 1 target
		 * -----------------
		 *   0 0 0 0 m_Walls
		 */
		m_Walls = m_Walls ^ target;
	}

	public bool HasWall(Wall target) {
		/* eg. Checking if a cell has a left wall.
		 *   1 1 1 1 m_Walls
		 * & 0 0 0 1 target
		 * -----------------
		 *   0 0 0 1 == target ?
		 */
		return (m_Walls & target) == target; 
	}

	public void SetType(Type target) {
		/* eg. Set cell as an entrance.
		 *   0 0 0 m_Type
		 * | 0 0 1 target
		 * --------------
		 *   0 0 1  m_Type
		 */
		m_Type = m_Type | target;
	}

	public void UnsetType(Type target) {
		/* eg. Unsetting a cell as an entrance.
		 *   0 0 1 m_Type
		 * & 1 1 0 ~target
		 * ---------------
		 *   0 0 0  m_Type
		 */
		m_Type = m_Type & (~target);
	}

	public void ToggleType(Type target) {
		/* eg. Toggle a cell as an entrance.
		 *   0 0 1 m_Type
		 * ^ 0 0 1 target
		 * --------------
		 *   0 0 0 m_Type
		 */
		m_Type = m_Type ^ target;
	}

	public Wall DeadEndOpening() {
		// Needs to be rewritten.
		
		if (!HasWall(Wall.Left)) {
			return Wall.Left;
		} else if (!HasWall(Wall.Up)) {
			return Wall.Up;
		} else if (!HasWall(Wall.Right)) {
			return Wall.Right;
		} else if (!HasWall(Wall.Down)) {
			return Wall.Down;
		}

		return Wall.None;
	}
}

}
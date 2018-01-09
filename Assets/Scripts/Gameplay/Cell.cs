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

// Flags if the cell is an entrance, an exit or none.
[System.Flags]
public enum Type {
	None     =      0,
	Entrance = 1 << 0,
	Exit     = 1 << 1

}

// Flags if the cell was already visited by an algorithm or if it's nearby a visited cell.
public enum Status {
	None     = 0,
	Visited  = 1,
	Neighbor = 2
}

public class Cell {
	int m_Size;
	bool m_HasChest;

	Status m_Status;
	Wall m_Walls;
	Type m_Type;

	public Cell(int size) {
		m_Size = size;

		SetWall (Wall.Left);
		SetWall (Wall.Up);
		SetWall (Wall.Right);
		SetWall (Wall.Down);
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
		/* eg. Setting left wall
		 * 0
		 */
		m_Walls = m_Walls | target;
	}

	public void UnsetWall(Wall target) {
		m_Walls = m_Walls & (~target);
	}

	public void ToggleWall(Wall target) {
		m_Walls = m_Walls ^ target;
	}

	public bool HasWall(Wall target) {
		return (m_Walls & target) == target; 
	}

	public void SetType(Type target) {
		m_Type = m_Type | target;
	}

	public void UnsetType(Type target) {
		m_Type = m_Type & (~target);
	}

	public void ToggleType(Type target) {
		m_Type = m_Type ^ target;
	}

	public Wall DeadEndOpening() {
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
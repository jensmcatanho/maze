using UnityEngine;
using System.Collections;

namespace Gameplay {

public class PrimCell : Cell {
    // Flags if the cell was already visited by an algorithm or if it's nearby a visited cell.
    public enum Status {
        None     = 0,
        Visited  = 1,
        Neighbor = 2,
    }
    
	public Status m_Status;

    public PrimCell(int x, int y, int size)
        : base(x, y, size) {
        
	}

}

}
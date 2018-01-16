using UnityEngine;
using System.Collections;

namespace Gameplay {

public class DFSCell : Cell {
    // Flags if the cell was already visited by an algorithm.
    public enum Status {
        None     = 0,
        Visited  = 1
    }
    
	public Status m_Status;

    public DFSCell(int x, int y, int size)
        : base(x, y, size) {
        
	}

}

}
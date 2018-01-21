using UnityEngine;
using System.Collections;

namespace Rendering {

public class Maze : MonoBehaviour {
	int m_NChests;

	public int NChests {
		get { return m_NChests; }
		set { m_NChests = value; }
	}
}

}
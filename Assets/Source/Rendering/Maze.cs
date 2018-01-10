using UnityEngine;
using System.Collections;

namespace Rendering {

public class Maze : MonoBehaviour {
	public GameObject m_Labyrinth;

	int m_NChests;

	public Maze(GameObject mazeObject) {
		m_Labyrinth = mazeObject;
	}

	public int NChests {
		get { return m_NChests; }
		set { m_NChests = value; }
	}
}

}
using UnityEngine;
using System.Collections;

namespace Core {

public enum MazeType {
	DFS,
	Prim
}

public class MainSystem : MonoBehaviour, IEventListener {
	[SerializeField]
	GameObject player;

	[SerializeField]
	 int mazeLength;

	[SerializeField]
	int mazeWidth;
	
	[SerializeField]
	int cellSize;

	[SerializeField]
	MazeType mazeType;

	public void CreateListeners() {
		EventManager.Instance.AddListener<Rendering.Events.MazeReady>(CreatePlayer);
	}

	void Awake() {
		CreateListeners();
	}

	void Start() {
		EventManager.Instance.QueueEvent(new Events.CreateNewMaze(mazeType, mazeLength, mazeWidth, cellSize));
	}

	void CreatePlayer(Rendering.Events.MazeReady e) {
		Instantiate (player, new Vector3 (1.0f * cellSize, 1.0f, 1.0f * cellSize), new Quaternion());
	}
}

}
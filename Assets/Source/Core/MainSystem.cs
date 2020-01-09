using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace Core {

public enum MazeType {
	DFS,
	Prim
}

public class MainSystem : Singleton<MainSystem>, IEventListener {
	static MainSystem _instance;

	[SerializeField]
	GameObject player;

	[SerializeField]
	GameplaySettings gameplaySettings;

	public void CreateListeners() {
		EventManager.Instance.AddListener<Rendering.Events.MazeRendered>(CreatePlayer);
        EventManager.Instance.AddListener<Input.Events.PlayButtonPressed>(LoadGame);
        EventManager.Instance.AddListener<Input.Events.MenuButtonPressed>(LoadMainMenu);
	}

	protected MainSystem() {

	}

	void Awake() {
		CreateListeners();
    	DontDestroyOnLoad(transform.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;

		// TODO: Make this a singleton parent class.
        if (_instance == null) {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            DestroyImmediate(gameObject);
        }
	}

	void CreatePlayer(Rendering.Events.MazeRendered e) {
		Instantiate (player, new Vector3 (1.0f * gameplaySettings.cellSize, 1.0f, 1.0f * gameplaySettings.cellSize), new Quaternion());
		EventManager.Instance.QueueEvent(new Events.GameStarted());
	}

	void LoadGame(Input.Events.PlayButtonPressed e) {
		gameplaySettings = e.gameplaySettings;
		SceneManager.LoadScene(1);
	}

	void LoadMainMenu(Input.Events.MenuButtonPressed e) {
		SceneManager.LoadScene(0);
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		SceneManager.SetActiveScene(scene);

		if (scene.buildIndex == 1) {
			EventManager.Instance.QueueEvent(new Events.GameSceneLoaded(gameplaySettings));
		} else if (scene.buildIndex == 0) {
			Debug.Log("Menu");
        	Cursor.visible = true;
		}
	}
}

namespace Events {

public class GameStarted : Core.Events.GameEvent {
    public GameStarted() {
        Debug.Log("Event :: GameStarted");
    }
}

}

namespace Events {

public class GameSceneLoaded : GameEvent {
    public MazeType mazeType { get; private set; }

	public int mazeLength { get; private set; }

	public int mazeWidth { get; private set; }
	
	public int cellSize  { get; private set; }

    public GameSceneLoaded(GameplaySettings gameplaySettings) {
        Debug.Log("Event :: Core :: GameSceneLoaded");
        mazeType = gameplaySettings.mazeType;
        mazeLength = gameplaySettings.mazeLength;
        mazeWidth = gameplaySettings.mazeWidth;
        cellSize = gameplaySettings.cellSize;
    }
}

}

}
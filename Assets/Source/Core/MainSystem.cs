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
		EventManager.Instance.AddListener<Rendering.Events.MazeReady>(CreatePlayer);
        EventManager.Instance.AddListener<Input.Events.LoadGame>(LoadGame);
        EventManager.Instance.AddListener<Input.Events.LoadMainMenu>(LoadMainMenu);
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

	void CreatePlayer(Rendering.Events.MazeReady e) {
		Instantiate (player, new Vector3 (1.0f * gameplaySettings.cellSize, 1.0f, 1.0f * gameplaySettings.cellSize), new Quaternion());
		EventManager.Instance.QueueEvent(new Events.GameStarted());
	}

	void LoadGame(Input.Events.LoadGame e) {
		gameplaySettings = e.gameSettings;
		SceneManager.LoadScene(1);
		//StartCoroutine(LoadGameAsync(1));
	}

	void LoadMainMenu(Input.Events.LoadMainMenu e) {
		SceneManager.LoadScene(0);
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		SceneManager.SetActiveScene(scene);

		if (scene.buildIndex == 1) {
			EventManager.Instance.QueueEvent(new Events.CreateNewMaze(gameplaySettings));
		} else if (scene.buildIndex == 0) {
			Debug.Log("Menu");
        	Cursor.visible = true;
		}
	}
}

}
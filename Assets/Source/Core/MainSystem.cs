using UnityEngine;
using UnityEngine.SceneManagement;
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
	GameplaySettings gameplaySettings;

	public void CreateListeners() {
		EventManager.Instance.AddListener<Rendering.Events.MazeReady>(CreatePlayer);
        EventManager.Instance.AddListener<Input.Events.LoadGame>(LoadGame);
	}

	void Awake() {
		CreateListeners();
    	DontDestroyOnLoad(transform.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void CreatePlayer(Rendering.Events.MazeReady e) {
		Instantiate (player, new Vector3 (1.0f * gameplaySettings.cellSize, 1.0f, 1.0f * gameplaySettings.cellSize), new Quaternion());
		EventManager.Instance.QueueEvent(new Events.GameStarted());
		SceneManager.UnloadSceneAsync(0);
	}

	void LoadGame(Input.Events.LoadGame e) {
		gameplaySettings = e.gameSettings;
		StartCoroutine(LoadGameAsync(1));
	}

	IEnumerator LoadGameAsync(int sceneIndex) {
		AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);

		while (!operation.isDone) {
			float progress = Mathf.Clamp01(operation.progress / .9f);
			EventManager.Instance.QueueEvent(new Events.LoadingProgress(progress));

			yield return null;
		}
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		if (scene.buildIndex == 1) {
			SceneManager.SetActiveScene(scene);
			EventManager.Instance.QueueEvent(new Events.CreateNewMaze(gameplaySettings));
		}
	}
}

}
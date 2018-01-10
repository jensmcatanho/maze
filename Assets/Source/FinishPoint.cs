using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour {
	void OnTriggerEnter() {
		SceneManager.LoadScene("endscene");

	}
}

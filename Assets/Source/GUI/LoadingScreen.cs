using UnityEngine;
using UnityEngine.UI;

namespace GUI {

public class LoadingScreen : MonoBehaviour, Core.IEventListener {
    public Text progressText;

    public void CreateListeners() {
        Core.EventManager.Instance.AddListener<Input.Events.LoadGame>(LoadGame);
        Core.EventManager.Instance.AddListener<Core.Events.LoadingProgress>(UpdateLoadingProgress);
    }

    void Awake() {
        CreateListeners();
    }

    void LoadGame(Input.Events.LoadGame e) {
        progressText.gameObject.SetActive(true);
    }

    void UpdateLoadingProgress(Core.Events.LoadingProgress e) {
        progressText.text = e.progress * 100.0f + "%";
    }
}

}
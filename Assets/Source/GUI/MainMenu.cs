using UnityEngine;
using UnityEngine.UI;

namespace GUI {

public class MainMenu : MonoBehaviour, Core.IEventListener {

    public void CreateListeners() {
        Core.EventManager.Instance.AddListener<Input.Events.LoadGame>(LoadGame);
    }

    void Awake() {
        CreateListeners();
    }

    void LoadGame(Input.Events.LoadGame e) {
        gameObject.SetActive(false);
    }
}

}
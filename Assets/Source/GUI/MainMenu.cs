using UnityEngine;
using UnityEngine.UI;

namespace GUI {

public class MainMenu : MonoBehaviour, Core.IEventListener {

    public void CreateListeners() {
        Core.EventManager.Instance.AddListener<Input.Events.LoadGame>(LoadGame);
        Core.EventManager.Instance.AddListener<Input.Events.LoadMainMenu>(LoadMainMenu);
    }

    void Awake() {
        CreateListeners();
    }

    void LoadGame(Input.Events.LoadGame e) {
        gameObject.SetActive(false);
    }

    void LoadMainMenu(Input.Events.LoadMainMenu e) {
        Cursor.visible = true;
    }
}

}
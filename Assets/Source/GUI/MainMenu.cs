using UnityEngine;
using UnityEngine.UI;

namespace GUI {

public class MainMenu : MonoBehaviour, Core.IEventListener {

    public void CreateListeners() {
        Core.EventManager.Instance.AddListener<Input.Events.PlayButtonPressed>(HideMenu);
        Core.EventManager.Instance.AddListener<Input.Events.MenuButtonPressed>(DisplayMenu);
    }

    void Awake() {
        CreateListeners();
    }

    void HideMenu(Input.Events.PlayButtonPressed e) {
        Cursor.visible = false;
    }

    void DisplayMenu(Input.Events.MenuButtonPressed e) {
        Cursor.visible = true;
    }
}

}
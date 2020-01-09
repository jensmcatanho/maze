using UnityEngine;
using UnityEngine.UI;

namespace Gameplay {

public class MainMenu : MonoBehaviour, Core.IEventListener {

    public void CreateListeners() {
        Core.EventManager.Instance.AddListener<Input.Events.PlayButtonPressed>(HideMenu);
        Core.EventManager.Instance.AddListener<Input.Events.MenuButtonPressed>(DisplayMenu);
    }

    void Awake() {
        CreateListeners();
    }

    void HideMenu(Input.Events.PlayButtonPressed e) {
        gameObject.SetActive(false);
    }

    void DisplayMenu(Input.Events.MenuButtonPressed e) {
        gameObject.SetActive(true);
    }
}

}
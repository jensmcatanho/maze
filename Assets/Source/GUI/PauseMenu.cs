using UnityEngine;
using UnityEngine.UI;

namespace GUI {

public class PauseMenu : MonoBehaviour, Core.IEventListener {
    public void CreateListeners() {
        Core.EventManager.Instance.AddListener<Events.DisplayPauseMenu>(DisplayPauseMenu);
        Core.EventManager.Instance.AddListener<Events.ClosePauseMenu>(ClosePauseMenu);
    }

    void Awake() {
        CreateListeners();
        gameObject.SetActive(false);
    }

    void DisplayPauseMenu(Events.DisplayPauseMenu e) {
        gameObject.SetActive(true);
    }

    void ClosePauseMenu(Events.ClosePauseMenu e) {
        gameObject.SetActive(false);
    }
}

}
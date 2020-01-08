using UnityEngine;
using UnityEngine.UI;

namespace GUI {

public class PauseMenu : MonoBehaviour, Core.IEventListener {
    public void CreateListeners() {
        Core.EventManager.Instance.AddListener<Input.Events.PauseGame>(DisplayPauseMenu);
        Core.EventManager.Instance.AddListener<Input.Events.ResumeGame>(ClosePauseMenu);
    }

    void Awake() {
        CreateListeners();
        gameObject.SetActive(false);
    }

    public void DisplayPauseMenu(Input.Events.PauseGame e) {
        Cursor.visible = true;
        gameObject.SetActive(true);
    }

    public void ClosePauseMenu(Input.Events.ResumeGame e) {
        Cursor.visible = false;
        gameObject.SetActive(false);
    }
}

}
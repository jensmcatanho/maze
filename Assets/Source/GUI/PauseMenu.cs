using UnityEngine;

namespace GUI {

public class PauseMenu : MonoBehaviour, Core.IEventListener {
    public void CreateListeners() {
        Core.EventManager.Instance.AddListener<Input.Events.PauseButtonPressed>(DisplayCursor);
        Core.EventManager.Instance.AddListener<Input.Events.ResumeGameButtonPressed>(HideCursor);
    }

    void Awake() {
        CreateListeners();
    }

    public void DisplayCursor(Input.Events.PauseButtonPressed e) {
        Cursor.visible = true;
    }

    public void HideCursor(Input.Events.ResumeGameButtonPressed e) {
        Cursor.visible = false;
    }
}

}
using UnityEngine;

namespace Input {

public class PauseMenu : MonoBehaviour, Core.IEventListener {
    bool isPaused = false;

    public void CreateListeners() {
        Core.EventManager.Instance.AddListener<Events.PauseButtonPressed>(Pause);
    }

    void Awake() {
        CreateListeners();
    }

     void Update() {
        if (isPaused && UnityEngine.Input.GetKeyDown(KeyCode.Escape)) {
            Core.EventManager.Instance.QueueEvent(new Events.ResumeGameButtonPressed());
        }
    }

    public void Pause(Events.PauseButtonPressed e) {
        isPaused = true;
    }

    public void ResumeButton() {
        isPaused = false;
        Core.EventManager.Instance.QueueEvent(new Events.ResumeGameButtonPressed());
    }

    public void MenuButton() {
        isPaused = false;
        Core.EventManager.Instance.QueueEvent(new Events.MenuButtonPressed());
    }

    public void SettingsButton() {
        Debug.Log("Loading settings...");
    }

    public void ExitButton() {
        Debug.Log("Exiting game...");
    }
}

namespace Events {

public class MenuButtonPressed : Core.Events.GameEvent {
    public MenuButtonPressed() {
        Debug.Log("Event :: Input :: MenuButtonPressed");
    }
}

public class ResumeGameButtonPressed : Core.Events.GameEvent {
    public ResumeGameButtonPressed() {
        Debug.Log("Event :: Input :: ResumeGameButtonPressed");
    }
}

}


}
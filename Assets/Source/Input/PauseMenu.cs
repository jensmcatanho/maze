using UnityEngine;

namespace Input {

public class PauseMenu : MonoBehaviour {
    public void ResumeButton() {
        InputSystem.Instance.ResumeGame();
    }

    public void MenuButton() {
        InputSystem.Instance.ResumeGame();
        Core.EventManager.Instance.QueueEvent(new Events.LoadMainMenu());
        Debug.Log("Loading main menu...");
    }

    public void SettingsButton() {
        Debug.Log("Loading settings...");
    }

    public void ExitButton() {
        Debug.Log("Exiting game...");
        Application.Quit();
    }
}

}
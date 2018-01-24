using UnityEngine;

namespace Input {

public class PauseMenu : MonoBehaviour {
    public void ResumeButton() {
        Core.EventManager.Instance.QueueEvent(new Events.ResumeGame());
        InputSystem.m_IsPaused = false;
    }

    public void MenuButton() {
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
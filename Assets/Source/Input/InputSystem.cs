using UnityEngine;

namespace Input {

public class InputSystem : MonoBehaviour {
    static InputSystem s_Instance = null;

    public static bool m_IsPaused;

    public static InputSystem Instance {
        get {
            if (s_Instance == null) {
                s_Instance = GameObject.FindObjectOfType (typeof(InputSystem)) as InputSystem;
            }
            
            return s_Instance;
        }
    }

    void Update() {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Escape)) {
            if (m_IsPaused) {
                ResumeGame();
            } else {
                PauseGame();
            }
        }
    }

    void PauseGame() {
        Core.EventManager.Instance.QueueEvent(new Gameplay.Events.PauseGame());
        Core.EventManager.Instance.QueueEvent(new GUI.Events.DisplayPauseMenu());
        m_IsPaused = true;
    }

    void ResumeGame() {
        Core.EventManager.Instance.QueueEvent(new Gameplay.Events.ResumeGame());
        Core.EventManager.Instance.QueueEvent(new GUI.Events.ClosePauseMenu());
        m_IsPaused = false;
    }
}

}
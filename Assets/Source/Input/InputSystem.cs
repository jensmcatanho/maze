using UnityEngine;

namespace Input {

public class InputSystem : MonoBehaviour, Core.IEventListener {
    static InputSystem s_Instance = null;

    public static bool m_IsPaused;
    public static bool m_IsInGame = false;

    public static InputSystem Instance {
        get {
            if (s_Instance == null) {
                s_Instance = GameObject.FindObjectOfType (typeof(InputSystem)) as InputSystem;
            }
            
            return s_Instance;
        }
    }

    public void CreateListeners() {
        Core.EventManager.Instance.AddListener<Core.Events.GameStarted>(GameStarted);
    }

    void Awake() {
        CreateListeners();
    }

    void Update() {
        if (m_IsInGame) {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
                if (m_IsPaused) {
                    ResumeGame();
                } else {
                    PauseGame();
                }
        }
    }

    void GameStarted(Core.Events.GameStarted e) {
        m_IsInGame = true;
    }

    void PauseGame() {
        Core.EventManager.Instance.QueueEvent(new Events.PauseGame());
        m_IsPaused = true;
    }

    void ResumeGame() {
        Core.EventManager.Instance.QueueEvent(new Events.ResumeGame());
        m_IsPaused = false;
    }
}

}
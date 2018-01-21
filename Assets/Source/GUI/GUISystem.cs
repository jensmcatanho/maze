using UnityEngine;

namespace GUI {

public class GUISystem : MonoBehaviour, Core.IEventListener {
    static GUISystem s_Instance = null;

    [SerializeField]
    public GameObject m_PauseMenuUI;

    public static GUISystem Instance {
        get {
            if (s_Instance == null) {
                s_Instance = GameObject.FindObjectOfType (typeof(GUISystem)) as GUISystem;
            }
            
            return s_Instance;
        }
    }

    public void CreateListeners() {
        Core.EventManager.Instance.AddListener<Events.DisplayPauseMenu>(DisplayPauseMenu);
        Core.EventManager.Instance.AddListener<Events.ClosePauseMenu>(ClosePauseMenu);
    }

    void Awake() {
        CreateListeners();
        m_PauseMenuUI.SetActive(false);
    }

    void DisplayPauseMenu(Events.DisplayPauseMenu e) {
        m_PauseMenuUI.SetActive(true);
    }

    void ClosePauseMenu(Events.ClosePauseMenu e) {
        m_PauseMenuUI.SetActive(false);
    }
}

}
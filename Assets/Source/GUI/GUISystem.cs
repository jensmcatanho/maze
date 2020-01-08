using UnityEngine;

namespace GUI {

public class GUISystem : MonoBehaviour, Core.IEventListener {
    static GUISystem s_Instance = null;

    [SerializeField]
    public GameObject m_MainMenu;

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
        Core.EventManager.Instance.AddListener<Core.Events.GameStarted>(GameStarted);
    }

    void Awake() {
        CreateListeners();
    }

    void GameStarted(Core.Events.GameStarted e) {

    }
}

}
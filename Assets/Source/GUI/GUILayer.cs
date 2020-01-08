using UnityEngine;

namespace GUI {

public class GUILayer : MonoBehaviour, Core.IEventListener {
    static GUILayer s_Instance = null;

    [SerializeField]
    public GameObject m_MainMenuUI;

    [SerializeField]
    public GameObject m_PauseMenuUI;

    public static GUILayer Instance {
        get {
            if (s_Instance == null) {
                s_Instance = GameObject.FindObjectOfType (typeof(GUILayer)) as GUILayer;
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
		GameObject pauseMenu = Instantiate(m_PauseMenuUI) as GameObject;
        pauseMenu.transform.SetParent(gameObject.transform.Find("Canvas"));

        pauseMenu.GetComponent<RectTransform>().offsetMin = new Vector2();
        pauseMenu.GetComponent<RectTransform>().offsetMax = new Vector2();
    }
}

}
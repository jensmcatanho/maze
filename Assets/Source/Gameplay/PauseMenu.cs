using UnityEngine;

namespace Gameplay {

public class PauseMenu : MonoBehaviour, Core.IEventListener {
    public void CreateListeners() {
        Core.EventManager.Instance.AddListener<Input.Events.PauseButtonPressed>(ActivatePauseMenu);
        Core.EventManager.Instance.AddListener<Input.Events.ResumeGameButtonPressed>(DeactivatePauseMenu);
    }

    void Awake() {
        CreateListeners();
        gameObject.SetActive(false);
    }

    public void ActivatePauseMenu(Input.Events.PauseButtonPressed e) {
        gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void DeactivatePauseMenu(Input.Events.ResumeGameButtonPressed e) {
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }
}

}
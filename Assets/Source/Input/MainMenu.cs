using UnityEngine;
using UnityEngine.UI;

namespace Input {

public class MainMenu : MonoBehaviour, Core.IEventListener {
    public Button playButton;
    public Button exitButton;
    
    public InputField lengthInputField;
    public InputField widthInputField;
    
    public Dropdown algorithmDropdown;

    public void CreateListeners() {
        playButton.GetComponent<Button>().onClick.AddListener(PlayButton);
        exitButton.GetComponent<Button>().onClick.AddListener(ExitButton);
    }

    void Awake() {
        CreateListeners();
    }

    public void PlayButton() {
        Core.GameplaySettings gameplaySettings = ScriptableObject.CreateInstance<Core.GameplaySettings>();
        int.TryParse(lengthInputField.text, out gameplaySettings.mazeLength);
        int.TryParse(widthInputField.text, out gameplaySettings.mazeWidth);
        gameplaySettings.cellSize = 2;
        gameplaySettings.mazeType = (Core.MazeType)algorithmDropdown.value;

        Core.EventManager.Instance.QueueEvent(new Input.Events.PlayButtonPressed(gameplaySettings));
    }

    public void ExitButton() {
        Debug.Log("Exiting game...");
        Application.Quit();
    }
}


namespace Events {

public class PlayButtonPressed : Core.Events.GameEvent {
    public Core.GameplaySettings gameplaySettings { get; private set; }

    public PlayButtonPressed(Core.GameplaySettings gameplaySettings) {
        Debug.Log("Event :: Input :: PlayButtonPressed");
        this.gameplaySettings = gameplaySettings;
    }
    
}

}



}
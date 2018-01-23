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
        Core.GameplaySettings gameSettings = ScriptableObject.CreateInstance<Core.GameplaySettings>();
        int.TryParse(lengthInputField.text, out gameSettings.mazeLength);
        int.TryParse(widthInputField.text, out gameSettings.mazeWidth);
        gameSettings.cellSize = 2;
        gameSettings.mazeType = (Core.MazeType)algorithmDropdown.value;

        Core.EventManager.Instance.QueueEvent(new Input.Events.LoadGame(gameSettings));
    }

    public void ExitButton() {
        Debug.Log("Exiting game...");
        Application.Quit();
    }
}

}
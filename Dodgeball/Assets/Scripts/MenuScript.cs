using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameObject optionMenuCanvas;

    public void playGame() {
        SceneManager.LoadScene("PlayScene");
    }

    public void quitGame() {
        Application.Quit();
    }

    public void optionsMenu() {
        mainMenuCanvas.SetActive(!mainMenuCanvas.activeSelf);
        optionMenuCanvas.SetActive(!optionMenuCanvas.activeSelf);
    }

    public void resolution1920() {
        Screen.SetResolution(1920, 1080, true);
    }

    public void resolution2560() {
        Screen.SetResolution(2560, 1440, true);
    }
}

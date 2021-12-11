using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameStateScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameUI;

    public TMP_Text timerText;

    private float gameTimer = 60;

    public static bool gameResult = true;

    // Start is called before the first frame update
    void Start()
    {
        gameTimer = 60;
        gameResult = false;

        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update() {
        gameTimer -= Time.deltaTime;
        timerText.text = "Time Remaining: " + (int)gameTimer;

        if (gameTimer <= 0) {
            gameResult = false;
            SceneManager.LoadScene("EndScene", LoadSceneMode.Single);
        }

        if (Input.GetKeyDown("escape")) {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            gameUI.SetActive(!gameUI.activeSelf);
            if (pauseMenu.activeSelf) {
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    public void resumeGame() {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        gameUI.SetActive(!gameUI.activeSelf);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void quitGame() {
        SceneManager.LoadScene("MenuScene",LoadSceneMode.Single);
    }
}

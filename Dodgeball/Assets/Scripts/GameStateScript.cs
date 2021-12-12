using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameStateScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public TMP_Text scoreboardTimer;
    public TMP_Text scoreboardLeft;
    public TMP_Text scoreboardHit;

    public GameObject resumeButton;
    public GameObject optionsButton;
    public GameObject quitButton;

    public GameObject sensSlider;
    public GameObject backButton;

    private float gameTimer = 60;
    private int opponentsHit;
    private int opponentsLeft;
    public static bool gameResult = true;

    public Transform enemyContainer;

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

        updateScoreboard();

        if (gameTimer <= 0) {
            gameResult = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("EndScene", LoadSceneMode.Single);
        } else if (allEnemiesHit()) {
            gameResult = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("EndScene", LoadSceneMode.Single);
        }

        if (Input.GetKeyDown("escape")) {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
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

    private bool allEnemiesHit() {
        bool temp = true;
        int temp2 = 0;
        int temp3 = 0;
        foreach (Transform child in enemyContainer)
        {
            temp3++;
            if (child.GetComponent<HitScript>().hit == false) temp = false; else temp2++;
        }
        opponentsHit = temp2;
        opponentsLeft = temp3 - temp2;
        return temp;
    }

    public void resumeGame() {
        if (!resumeButton.activeSelf) toggleOptions();
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void quitGame() {
        SceneManager.LoadScene("MenuScene",LoadSceneMode.Single);
    }

    public void toggleOptions() {
        resumeButton.SetActive(!resumeButton.activeSelf);
        optionsButton.SetActive(!optionsButton.activeSelf);
        quitButton.SetActive(!quitButton.activeSelf);
        sensSlider.SetActive(!sensSlider.activeSelf);
        backButton.SetActive(!backButton.activeSelf);
    }

    private void updateScoreboard() {
        scoreboardTimer.text = "0:" + (int)gameTimer;
        scoreboardHit.text = "" + opponentsHit;
        scoreboardLeft.text = "" + opponentsLeft;
    }
}

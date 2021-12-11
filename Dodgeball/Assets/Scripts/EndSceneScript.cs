using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneScript : MonoBehaviour
{
    public GameObject lostCanvas;
    public GameObject wonCanvas;

    // Start is called before the first frame update
    void Start()
    {
        if (GameStateScript.gameResult == false) {
            lostCanvas.SetActive(true);
            wonCanvas.SetActive(false);
        }
        else if (GameStateScript.gameResult == true) {
            lostCanvas.SetActive(false);
            wonCanvas.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playAgain() {
        SceneManager.LoadScene("PlayScene");
    }

    public void quitToMenu() {
        SceneManager.LoadScene("MenuScene");
    }
}

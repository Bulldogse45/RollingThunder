using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceenLoader : MonoBehaviour
{
    private string highScoreScene = "highScore";

    public void LoadNextSceen() {

        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex + 1);
    }
    public void QuitGame() {

        Application.Quit();
    }
    public void HighScores() {

        SceneManager.LoadScene("highScoreTable");
    }
}

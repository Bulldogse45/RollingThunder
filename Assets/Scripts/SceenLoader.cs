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
    public void instructionsToStart() {

        SceneManager.LoadScene(0); 
    }
    public void toInstructions() {

        SceneManager.LoadScene("Instructions");
    }
    public void toSources() {

        SceneManager.LoadScene("Sources");
    }
}

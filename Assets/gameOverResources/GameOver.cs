using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int currentScore = 300;
    [SerializeField] GameObject highScoreContainer;
    [SerializeField] GameObject nonHighScoreButtons;
    int highScore = 100;

    private Transform highScoreInfo;
    private Transform highScoreTemp;
    
    [SerializeField] TextMeshProUGUI highScoreName;

    //static variables to be used in another scene's script
    public static string newName;
    public static int newScore;

    /* Start is called before the first frame update
     * Sets final score to show the score. Checks to see if 
     * the current score is in the top 10. If it is, 
     * have user enter their name, otherwise
     * provide user with the play again and quit buttons.
     */
    void Start()
    {
       scoreText.text = currentScore.ToString();
       if(currentScore < highScore)
        {
            highScoreContainer.SetActive(false);
        }
       else
        {
            nonHighScoreButtons.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void Awake()
    {
       
    }

    /*This function determines the index of the current scene.
     * If that index + 1 is greater than the number of scenes in the 
     * build, then you're currently on the game over scene so the start 
     * scene will be loader. Otherwise, it will load the next indexed scene
     */
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex + 1 >= SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(0);
        else
            SceneManager.LoadScene(currentSceneIndex + 1);
    }

    //This function quits the game. 
    public void QuitGame()
    {
        Application.Quit();
    }


    public void SubmitHighScore()
    {
        newName = highScoreName.text;
        newScore = highScore;
        SceneManager.LoadScene("highScoreTable");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Text.RegularExpressions;
using System;
using System.IO;

public class GameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    //[SerializeField] int currentScore = 300;
    [SerializeField] GameObject highScoreContainer;
    [SerializeField] GameObject nonHighScoreButtons;

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
        if(!File.Exists(Application.dataPath + "/highscores.txt"))
        {
            System.IO.File.WriteAllText(Application.dataPath + "/highscores.txt", "NA - 0 \nNA - 0 \nNA - 0 \nNA - 0 \nNA - 0 \nNA - 0 \nNA - 0 \nNA - 0 \nNA - 0 \nNA - 0 \n");
        }
        scoreText.text = ScoreScript.endScore.ToString();
        string[] scores = System.IO.File.ReadAllLines(Application.dataPath + "/highscores.txt");
        int lastScore = Int32.Parse(Regex.Match(scores[9], @"\d+").Value);
        if(ScoreScript.endScore < lastScore)
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

    //This function takes the user to the start scene    
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        BackgroundGrass.fallSpeed = -4f;
        GenerateObject.spawnTime = 1f;
        ScoreScript.currentScore = 0;
        ScoreScript.clockCount = 0;
    }

    //This function quits the game. 
    public void QuitGame()
    {
        Application.Quit();
    }


    public void SubmitHighScore()
    {
        newName = highScoreName.text;
        newScore = ScoreScript.endScore;
        SceneManager.LoadScene("highScoreTable");
    }
}

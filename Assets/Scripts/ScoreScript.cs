using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] public static int currentScore = 0;
    [SerializeField] int matchesCount = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI matchCountText;

    //Static variable to be used in other scripts
    public static int endScore;
    public float timer = 0;
    /* Start is called before the first frame update
     * Set text on scene to current score and call 
     * update score once per frame
     */
    void Start()
    {
        scoreText.text = currentScore.ToString();
        matchCountText.text = matchesCount.ToString();
        InvokeRepeating("UpdateScore", 0, 1f);
    }

    /*Code borrowed from: https://stackoverflow.com/questions/41641731/time-based-scoring-unity
     * This function gets the running time of the game and
     * adds points to the current score based on how long
     * the user has been playing and then updates the score
     * on the screen. 
     */
    void UpdateScore()
    {
        float time = Time.deltaTime;

        timer += time;
       
        if (timer > .02 && timer < .10)
        {
            currentScore += 2;
        }
        else if (timer >= .10 && timer < .20)
        {
            currentScore += 4;
        }
        else if (timer >= .20 && timer < .30)
        {
            currentScore += 6;
        }
        else if(timer >= .30)
        {
            currentScore += 8;
        }

        scoreText.text = currentScore.ToString();
        endScore = currentScore;
    }

    public void incrementMatchesCount(){
        matchesCount = matchesCount + 1;
        matchCountText.text = matchesCount.ToString();
    }
    public void decrementMatchesCount(){
        matchesCount = matchesCount - 1;
        matchCountText.text = matchesCount.ToString();
    }
    public int getMatchesCount(){
        return matchesCount;
    }
}

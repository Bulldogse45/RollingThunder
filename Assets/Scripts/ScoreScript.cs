using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] public static int currentScore = 0;
    [SerializeField] int matchesCount = 0;
    [SerializeField] public static int clockCount = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI matchCountText;
    [SerializeField] TextMeshProUGUI clockCountText;

    bool time1 = true;
    bool time2 = true;
    bool time3 = true;

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
       

        if (timer > .02 && timer < .40)
        {
            BackgroundGrass.constantFallSpeed = BackgroundGrass.fallSpeed;
            currentScore += 2;
        }
        else if (timer >= .40 && timer < .80)
        {
            if (time1 && Ball.slowDown) 
            {
                changeSpeed();
                time1 = false;
            }
            currentScore += 4;
            
        }
        else if (timer >= .80 && timer < 1.20)
        {
            if (time2 && Ball.slowDown)
            {
                changeSpeed();
                time2 = false;
            }
            currentScore += 6;
            
        }
        else if(timer >= 1.20)
        {
            if (time3 && Ball.slowDown)
            {
                changeSpeed();
                time3 = false;
            }
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

    public void scoreOnScreen()
    {
        scoreText.text = currentScore.ToString();
        endScore = currentScore;
    }

    public void incrementClockCount()
    {
        clockCount = clockCount + 1;
        clockCountText.text = clockCount.ToString();
    }
    public void decrementClockCount()
    {
        clockCount = clockCount - 1;
        clockCountText.text = clockCount.ToString();
    }
    public int getClockCount()
    {
        return clockCount;
    }

    public void changeSpeed()
    {
        BackgroundGrass.fallSpeed = BackgroundGrass.fallSpeed - .5f;
        BackgroundGrass.constantFallSpeed = BackgroundGrass.fallSpeed;
        GenerateObject.spawnTime = -1/(BackgroundGrass.fallSpeed / 4);
        GenerateObject.constantSpawnTime = GenerateObject.spawnTime;
    }
}

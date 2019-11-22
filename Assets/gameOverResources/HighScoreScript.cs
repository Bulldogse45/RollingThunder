using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Text;

public class HighScoreScript : MonoBehaviour
{
   
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;

    //Code Borrowed from: https://www.youtube.com/watch?v=iAbaqGYdnyI
    private void Awake()
    {
        //grab containers with the high score template and hide
        entryContainer = GameObject.Find("highScoreEntryTable").transform;
        entryTemplate = entryContainer.Find("highScoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        List<HighscoreEntry> highscores = new List<HighscoreEntry>();

        string path = Application.dataPath + "/highscores.txt";
        ReadFile(path, highscores);

        if (GameOver.newScore != 0 && GameOver.newName != null)
        {
            AddHighscoreEntry(GameOver.newScore, GameOver.newName, highscores);
        }

        for (int i = 0; i < highscores.Count; i++)
        {
            for (int j = i+1; j < highscores.Count; j++)
            {
                if (highscores[j].score > highscores[i].score)
                {
                    HighscoreEntry tmp = highscores[i];
                    highscores[i] = highscores[j];
                    highscores[j] = tmp;
                }
            }
        }

        if (GameOver.newScore != 0 && GameOver.newName != null)
        {
            highscores.RemoveAt(highscores.Count - 1);
        }
       


        highscoreEntryTransformList = new List<Transform>();
       
        for (int i = 0; i < highscores.Count; i++)
        {
            float templateHeight = 75f;

            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            entryTransform.gameObject.SetActive(true);

            int rank = i + 1;
            string rankString;

            rankString = rank.ToString();

            entryTransform.Find("rankText").GetComponent<Text>().text = rankString;

            int score = highscores[i].score;
            entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

            string name = highscores[i].name;
            entryTransform.Find("nameText").GetComponent<Text>().text = name;
        }


        string stringForFile = "";
         for(int i = 0; i < highscores.Count; i++)
        {
            stringForFile = stringForFile + highscores[i].name + "-" + highscores[i].score + "\n";
        }
        File.WriteAllText(path, stringForFile);


    }

    private void ReadFile(string fileName, List<HighscoreEntry> highscores)
    {
        string line;

        StreamReader theReader = new StreamReader(fileName, Encoding.Default);
      
        using (theReader)
        {
            do
            {
                line = theReader.ReadLine();

                if (line != null)
                {
                    string[] entries = line.Split('-');
                    if (entries.Length > 0)
                        DoStuff(entries, highscores);
                }
            }
            while (line != null);
            // Done reading, close the reader and return true to broadcast success    
            theReader.Close();

        }
    }

    private void AddHighscoreEntry(int score, string name, List<HighscoreEntry> highscores)
    {
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };
        highscores.Add(highscoreEntry);

    }

    private void DoStuff(string[] entries, List<HighscoreEntry> highscores)
    {
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = int.Parse(entries[1]), name = entries[0] };
        highscores.Add(highscoreEntry);
    }

 
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }


    //Takes user to the start scene
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

}

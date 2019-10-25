using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameNew;
    [SerializeField] TextMeshProUGUI score;
    
    // Start is called before the first frame update
    void Start()
    {
        nameNew.text = GameOver.newName.ToString();
        score.text = GameOver.newScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

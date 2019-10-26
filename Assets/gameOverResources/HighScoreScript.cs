using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour
{
   /* [SerializeField] Text nameNew;
    [SerializeField] Text score;
    
    // Start is called before the first frame update
    void Start()
    {
        nameNew.text = GameOver.newName.ToString();
        score.text = GameOver.newScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
    
    private Transform entryContainer;
    private Transform entryTemplate;

    private void Awake()
    {
        entryContainer = GameObject.Find("highScoreEntryTable").transform; 
        entryTemplate = entryContainer.Find("highScoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        float templateHeight = 75f;

        for( int i=0; i<10; i++)
        {
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent < RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, - templateHeight *i );
            entryTransform.gameObject.SetActive(true);
        }
        
    }
}

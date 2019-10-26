using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.Audio; 

public class MouseOver : MonoBehaviour {


    [SerializeField] AudioClip hover;
    [SerializeField] AudioClip click; 
    [SerializeField] float ChangeSize = 250;
    [SerializeField] float size = 200; 

    Color color;
    public AudioSource source;

    TMP_Text textmeshPro;

    private void Start() {

        textmeshPro = GetComponentInChildren<TMP_Text>();
        color = textmeshPro.color;
        size = textmeshPro.fontSize; 
    }
    public void ChangeText() {

        textmeshPro.fontSize = ChangeSize;
        textmeshPro.color = new Color(224, 126, 41, 1);
        source.PlayOneShot(hover);
      
    }
    public void ChangeTextBack() {

        textmeshPro.fontSize = size;
        textmeshPro.color = color; 
    }
    public void ClickEvent() {

        textmeshPro.color = Color.red;
        source.PlayOneShot(click);
    }
}

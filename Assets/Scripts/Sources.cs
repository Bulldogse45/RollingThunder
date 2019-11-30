using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Sources : MonoBehaviour
{

    public GameObject sourceText;
    String[] sourceLinks = new String[] {
        "https://graphicriver.net/item/animal-pets-grooming-and-healthcare-flat-colorful-vector-icons/14484763",
        "https://www.zapsplat.com",
        "https://www.freepik.com/premium-vector/vector-illustration-garden-tree-with-green-grass_5589457.htm#page=1&query=garden&position=14",
        "http://clipart-library.com/clock-images-free.html",
        "https://www.webnots.com/download-free-keyboard-key-images-in-black/",
        "https://opengameart.org/content/18-32-x-32-basic-long-grassy-tiles",
        "https://opengameart.org/content/pixel-explosion-12-frames",
        "https://opengameart.org/content/matches",
        "https://graphicriver.net/item/game-animals-sprite-sheet-volume-1/7739810",
        "https://opengameart.org/content/orbs",
        "https://www.youtube.com/channel/UCYbK_tjZ2OrIZFBvU6CCMiA",
        "https://www.udemy.com/course/unitycourse/learn/lecture/10761154"
    }; 
    String[] sources = new String[] {
        "Hamster, cage, and food clipart purchased: \n\nhttps://graphicriver.net/item/animal-pets-grooming-and-healthcare-flat-colorful-vector-icons/14484763", 
        "Clock Sound, Ticking, Food Sound, Match Strike: \n\n Sound effects obtained from https://www.zapsplat.com", 
        "Menu Yard: \n\nhttps://www.freepik.com/premium-vector/vector-illustration-garden-tree-with-green-grass_5589457.htm#page=1&query=garden&position=14",
        "Clock: \n\nhttp://clipart-library.com/clock-images-free.html",
        "Keys: \n\nhttps://www.webnots.com/download-free-keyboard-key-images-in-black/",
        "Gameplay Grass: \n\nhttps://opengameart.org/content/18-32-x-32-basic-long-grassy-tiles - open source",
        "Explosion: \n\nhttps://opengameart.org/content/pixel-explosion-12-frames - open source",
        "Matches: \n\nhttps://opengameart.org/content/matches - open source",
        "Gameplay Hamster: \n\nhttps://graphicriver.net/item/game-animals-sprite-sheet-volume-1/7739810 - license purchased",
        "Hamster Ball: \n\nhttps://opengameart.org/content/orbs",
        "Unity Tutorial: \n\nhttps://www.youtube.com/channel/UCYbK_tjZ2OrIZFBvU6CCMiA",
        "Unity Tutorial: \n\nhttps://www.udemy.com/course/unitycourse/learn/lecture/10761154"
    }; 
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SourceSpawns());
    }

    IEnumerator SourceSpawns() {
        int i = 0;
        while (true) {
            yield return new WaitForSeconds(4);
            GameObject source = SpawnSource(i);
            if(i<sources.Length - 1){
                i++;
            } else {
                i = 0;
            }
            Destroy(source, 6);
        }
    }
    private GameObject SpawnSource(int sourceIndex) {
        GameObject source = Instantiate(sourceText);
        source.GetComponent<TextMeshProUGUI>().text = sources[sourceIndex];
        source.transform.parent = GetComponentsInParent<Canvas>()[0].transform;
        source.transform.position = new Vector3(150, -200, -1);
        source.GetComponent<sourceLink>().link = sourceLinks[sourceIndex];
        source.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 100);
        return source;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] ScoreScript ss;
    void Update()
    {
        Rigidbody2D rb2D = GetComponent<Rigidbody2D>();
        if (Input.GetKey(KeyCode.A)){
            rb2D.velocity = new Vector2(-12f, 0f);
        }
        if (Input.GetKey(KeyCode.D)){
            print("This is a test");
            rb2D.velocity = new Vector2(15f, 0f);
        }
        if (Input.GetKey(KeyCode.W)){
            rb2D.velocity = new Vector2(0f, 7.5f);
        }
        if (Input.GetKey(KeyCode.S)){
            rb2D.velocity = new Vector2(0f, -12f);
        }
    }
    void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.name == "Matches") 
        {
            Destroy(collision.gameObject);
            ss.incrementMatchesCount();
            print("Got it!");
        }
    }
    
}

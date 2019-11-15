using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] ScoreScript ss;
    [SerializeField] AudioClip clock;
    [SerializeField] AudioClip eat;
    [SerializeField] AudioClip impact;
    public float speed;
    AudioSource audio;


    public void Start()
    {
        audio = GetComponent<AudioSource>();
        speed = 1;
    }
    void Update()
    {
        Rigidbody2D rb2D = GetComponent<Rigidbody2D>();
        if (Input.GetKey(KeyCode.A))
        {
            rb2D.velocity = new Vector2(-12f * speed, rb2D.velocity.y);
        }
        if (Input.GetKey(KeyCode.D))
        {

            rb2D.velocity = new Vector2(15f * speed, rb2D.velocity.y);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, 7.5f * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, -12f * speed);
        }
        if (Input.GetKey(KeyCode.K))
        {
            if (ss.getClockCount() > 0)
            {
                audio.clip = clock;
                audio.Play();
                ss.decrementClockCount();
                
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Matches"))
        {
            Destroy(collision.gameObject);
            ss.incrementMatchesCount();
        }
        if (collision.gameObject.name.Contains("Clock"))
        {
            audio.clip = impact;
            audio.Play();
            Destroy(collision.gameObject);
            ss.incrementClockCount();
        }
        if (collision.gameObject.name.Contains("bowl"))
        {
            audio.clip = eat;
            audio.Play();
            Destroy(collision.gameObject);
            ScoreScript.currentScore += 5;
            ss.scoreOnScreen();
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (ss.getMatchesCount() > 0 && Input.GetKey(KeyCode.J) && collision.gameObject.name.Contains("Hedge"))
        {
            Destroy(collision.gameObject);
            ss.decrementMatchesCount();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] ScoreScript ss;
    [SerializeField] AudioClip clock;
    [SerializeField] AudioClip eat;
    [SerializeField] AudioClip impact;
    [SerializeField] GameObject bushBurn;
    [SerializeField] AudioClip speedupSound; 

    AudioSource audio;
    [SerializeField] float carrotSeedUp = 2f;
    public float speedPercentage = 1;
    public float speed = 11f;
    private bool carrotSpeed = false;
    private float carrotTime = 0f;
    private float timeOfCarrotSpeed = 3f;
    public static bool slowDown = true; 


    public void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        Rigidbody2D rb2D = GetComponent<Rigidbody2D>();
        if (Input.GetKey(KeyCode.A)) {
            rb2D.velocity = new Vector2(-speed * speedPercentage, rb2D.velocity.y);
        }
        if (Input.GetKey(KeyCode.D)) {

            rb2D.velocity = new Vector2(speed * speedPercentage, rb2D.velocity.y);
        }
        if (Input.GetKey(KeyCode.W)) {
            rb2D.velocity = new Vector2(rb2D.velocity.x, speed * speedPercentage);
        }
        if (Input.GetKey(KeyCode.S)) {
            rb2D.velocity = new Vector2(rb2D.velocity.x, -speed * speedPercentage);
        }
        if (carrotSpeed) {

            carrotSpeed = carrotCheck(Time.fixedTime - carrotTime);
            print(carrotSpeed);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (ss.getClockCount() > 0)
            {
                audio.clip = clock;
                audio.Play();
                StartCoroutine(Speed());
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
        if (collision.gameObject.name.Contains("Carrot")) {

            audio.clip = speedupSound;
            audio.Play();
            Destroy(collision.gameObject);
            carrotSpeed = true;
            carrotTime = Time.fixedTime;
        }

    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if(ss.getMatchesCount() > 0 && Input.GetKey(KeyCode.J) && collision.gameObject.name.Contains("HedgePart")) 
        {
            HedgePart[] childBushes = collision.gameObject.GetComponentsInChildren<HedgePart>();
            foreach(HedgePart bush in childBushes){
                bush.burnSelf();
            }
            Destroy(collision.gameObject);
            ss.decrementMatchesCount();
        }
    }
    private bool carrotCheck(float time) {

        SpriteRenderer ball = GetComponent<SpriteRenderer>();

        if (time <= timeOfCarrotSpeed) {

            speedPercentage = carrotSeedUp;

            ball.color = new Color(Random.Range(.0f, .9f), Random.Range(.0f, .9f), Random.Range(.0f, .9f), 1);

            return true;
        }
        ball.color = Color.white;

        speedPercentage = 1;

        return false;
    }

    IEnumerator Speed()
    {
        slowDown = false;
        int sec = 8;
        float time = 0;
        BackgroundGrass.fallSpeed = -2f;
        GenerateObject.spawnTime = 2f;
        while (time < sec)
        {
            time += Time.deltaTime;
            yield return null;
        }
        slowDown = true;
        BackgroundGrass.fallSpeed = BackgroundGrass.constantFallSpeed;
        GenerateObject.spawnTime = GenerateObject.constantSpawnTime;
    }

}

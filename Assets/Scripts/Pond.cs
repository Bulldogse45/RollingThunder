using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pond : MonoBehaviour
{
    private float speed;
    float speedOfPond = 4f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;


    private void Start() {
    
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(rb.velocity.x, speedOfPond);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        Physics2D.IgnoreLayerCollision(8, 5);
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.name == "Ball") {

            collision.gameObject.GetComponentInParent<Ball>().speedPercentage = .2f;
            collision.gameObject.GetComponentInParent<Ball>().GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            collision.gameObject.GetComponentInParent<Ball>().GetComponent<Rigidbody2D>().gravityScale = 0;
        }

    }
    private void OnTriggerExit2D(Collider2D collision) {

        if (collision.gameObject.name == "Ball") {

            collision.gameObject.GetComponentInParent<Ball>().speedPercentage = 1;
            collision.gameObject.GetComponentInParent<Ball>().GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
    void Update() {

        if (transform.position.y > screenBounds.y + 10) {

            Destroy(gameObject);
        }
    }
}

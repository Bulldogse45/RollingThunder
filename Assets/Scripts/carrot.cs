using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carrot : MonoBehaviour {

    float carrotSpeed = 4f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start() {

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(rb.velocity.x, carrotSpeed);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        Physics2D.IgnoreLayerCollision(8, 5);
    }

    // Update is called once per frame
    void Update() {

        if (transform.position.y > screenBounds.y + 10) {

            Destroy(gameObject);
        }
    }
}

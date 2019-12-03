using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HedgePart : MonoBehaviour
{
    [SerializeField] GameObject bushBurn;
    [SerializeField] AudioClip matchStrike;
    float speed = 4f;
    private Rigidbody2D rb; 
    private Vector2 screenBounds; 
    // Start is called before the first frame update
    public void burnSelf()
    {
        Vector3 position = transform.position;
        position.z = -.1f;
        GameObject burningBush = Instantiate(bushBurn, position, transform.rotation);
        rb = burningBush.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(rb.velocity.x, speed);
        AudioSource.PlayClipAtPoint(matchStrike, Camera.main.transform.position);
        // https://www.zapsplat.com/sound-effect-category/game-sounds/
        // include message “Sound effects obtained from https://www.zapsplat.com“

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        Physics2D.IgnoreLayerCollision(8, 5);
    }
}



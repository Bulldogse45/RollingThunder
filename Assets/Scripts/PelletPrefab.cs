using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletPrefab : MonoBehaviour
{
    private Rigidbody2D rbPellet;
    private Vector2 screenBoundsPellet;

    // Start is called before the first frame update
    void Start()
    {
        rbPellet = GetComponent<Rigidbody2D>();
        rbPellet.velocity = new Vector2(rbPellet.velocity.x, BackgroundGrass.fallSpeed * -1);
        screenBoundsPellet = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        Physics2D.IgnoreLayerCollision(8, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > screenBoundsPellet.y + 10)
        {
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        rbPellet.velocity = new Vector2(rbPellet.velocity.x, BackgroundGrass.fallSpeed * -1);
    }
}
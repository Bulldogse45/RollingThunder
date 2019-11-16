﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockPrefab : MonoBehaviour
{
    public static float speedClock = 4f;
    private Rigidbody2D rbClock;
    private Vector2 screenBoundsClock;

    // Start is called before the first frame update
    void Start()
    {
        rbClock = GetComponent<Rigidbody2D>();
        rbClock.velocity = new Vector2(rbClock.velocity.x, speedClock);
        screenBoundsClock = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        Physics2D.IgnoreLayerCollision(8, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > screenBoundsClock.y + 10)
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGrass : MonoBehaviour
{
    public static float fallSpeed = -4f;
    public static float constantFallSpeed;
    Vector2 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    void FixedUpdate()
    {
        // help from this video on scrolling background
        // https://www.youtube.com/watch?v=IgZQjGyB9zg
        float newPosition = Mathf.Repeat (Time.time * fallSpeed, 10f);
        transform.position = startPosition + Vector2.down * newPosition;
    }
}

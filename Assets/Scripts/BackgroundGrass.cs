using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGrass : MonoBehaviour
{
    float fallSpeed = -4f;
    Vector2 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newPosition = Mathf.Repeat (Time.time * fallSpeed, 10f);
        transform.position = startPosition + Vector2.down * newPosition;
    }
}

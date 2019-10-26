using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroll : MonoBehaviour
{

    [SerializeField] float speed = 0.2f;
    [SerializeField] Renderer rndr; 

    // Update is called once per frame
    private void FixedUpdate() {

        Vector2 offset = new Vector2(Time.deltaTime * speed, 0);
        rndr.material.mainTextureOffset += offset; 
    }
}

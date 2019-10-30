using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hamster : MonoBehaviour
{
    [SerializeField] Animator animator;
    float speed = 10f;
    [SerializeField]float horizontalMovement = 0f;

    // Update is called once per frame
    void Update()
    {
        // https://www.youtube.com/watch?v=hkaysu1Z-N8 for animation tutorial
        horizontalMovement = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("speed", Mathf.Abs(horizontalMovement));
        // https://answers.unity.com/questions/952558/how-to-flip-sprite-horizontally-in-unity-2d.html
        if(horizontalMovement < 0){
            GetComponent<SpriteRenderer>().flipX  = true;
        } else if(horizontalMovement > 0) {
            GetComponent<SpriteRenderer>().flipX  = false;
        }
        
    }
}

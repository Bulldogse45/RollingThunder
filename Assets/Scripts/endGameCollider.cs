using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGameCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
   {
        //print(collision.gameObject.name);
        if (collision.gameObject.name == "Ball") {

            print("hello");
            SceneManager.LoadScene("GameOver");
        }
   }
}

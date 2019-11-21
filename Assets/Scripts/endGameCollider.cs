using UnityEngine;
using UnityEngine.SceneManagement;


public class endGameCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
   {
        
        if (collision.gameObject.name == "Ball") {
            SceneManager.LoadScene("GameOver");
        }
   }
}

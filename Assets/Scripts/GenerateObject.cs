using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObject : MonoBehaviour
{
   [SerializeField] float spawnTime = 1.0f;
   [SerializeField] int path = 3;

   public GameObject[] prefabs = new GameObject[11];
   public GameObject matches;
   private float screenLeft; 
   private Vector2 screenBounds;
 
   // Start is called before the first frame update
   void Start()
   {
     screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
     screenLeft = screenBounds.x;
     StartCoroutine(objectsSpawns());
 
   }
   void Spawn() {
     
     GameObject obj = Instantiate(prefabs[Random.Range(0, prefabs.Length)]);
     float set = Random.Range(-screenBounds.x, screenBounds.x + 5);
     obj.transform.position = new Vector2(0, screenBounds.y * -2f);
 
   }
   IEnumerator objectsSpawns() {
     while (true) {
       yield return new WaitForSeconds(spawnTime);
         Spawn();
    }
  }
 
  void Update()
  {
    addMatchCheck(); 
  }
 
  public void addMatchCheck()
  {
    int matchRandom = Random.Range(0, 1000);
    if(matchRandom == 0)
    {
      GameObject newMatches = Instantiate(matches);
      float xCoor = Random.Range(-screenBounds.x, screenBounds.x + 5);
      float yCoor = Random.Range(-screenBounds.y -5, screenBounds.y - 15);
      newMatches.transform.position = new Vector3(xCoor, yCoor, -.01f);
    }
  }
}

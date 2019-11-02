using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObject : MonoBehaviour
{

    [SerializeField] float spawnTime = 1.0f;
    [SerializeField] int path = 3;

    public GameObject[] prefabs = new GameObject[11];

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
        print(screenBounds.x); 
                
    }
    IEnumerator objectsSpawns() {
        while (true) {
            yield return new WaitForSeconds(spawnTime);
            Spawn();

        }
    }
}


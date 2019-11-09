using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    public GameObject pellet;
    private Vector2 screenArea;


    // Start is called before the first frame update
    void Start()
    {
        screenArea = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(pelletSpawns());

    }
    void SpawnPellet()
    {
        GameObject obj = Instantiate(pellet);
        float set = Random.Range(-screenArea.x, screenArea.x);
        obj.transform.position = new Vector3(set, screenArea.y * -3f, -0.1f);
    }

    IEnumerator pelletSpawns()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(2.0f, 6.0f));
            SpawnPellet();

        }
    }
}


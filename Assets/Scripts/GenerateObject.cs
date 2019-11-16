using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObject : MonoBehaviour {
    [SerializeField] float spawnTime = 1.0f;
    [SerializeField] int path = 3;

    public GameObject[] prefabs = new GameObject[11];
    public GameObject matches;
    public GameObject Pond;
    public GameObject carrot;
    private float screenLeft;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start() {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        screenLeft = screenBounds.x;
        StartCoroutine(objectsSpawns());
        StartCoroutine(pondSpawns());
        StartCoroutine(carrotSpawn());

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
    IEnumerator pondSpawns() {

        while (true) {
            yield return new WaitForSeconds(Random.Range(2.0f, 6.0f));
            spawnPond();
        }
    }
    IEnumerator carrotSpawn() {

        while (true) {
            yield return new WaitForSeconds(Random.Range(2.0f, 6.0f) + 2);
            spawnCarrot();
        }
    }
    void Update() {

        addMatchCheck();
    }

    public void addMatchCheck() {
        int matchRandom = Random.Range(0, 500);

        if (matchRandom == 0) {
            GameObject newMatches = Instantiate(matches);
            float xCoor = Random.Range(-screenBounds.x, screenBounds.x + 5);
            float yCoor = Random.Range(-screenBounds.y - 5, screenBounds.y - 15);
            newMatches.transform.position = new Vector3(xCoor, yCoor, -.01f);
        }
    }
    void spawnPond() {

        GameObject obj = Instantiate(Pond);
        float set = Random.Range(-screenBounds.x, screenBounds.x);
        obj.transform.position = new Vector3(set, screenBounds.y * -3f, -0.1f);
    }
    void spawnCarrot() {

        GameObject obj = Instantiate(carrot);
        float set = Random.Range(-screenBounds.x, screenBounds.x);
        obj.transform.position = new Vector3(set, screenBounds.y * -3f, -0.1f);
    }
}

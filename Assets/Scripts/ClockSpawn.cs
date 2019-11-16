﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockSpawn : MonoBehaviour
{
    public GameObject clock;
    private Vector2 screenArea;


    // Start is called before the first frame update
    void Start()
    {
        screenArea = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(clockSpawns());

    }
    void SpawnClock()
    {
        GameObject obj = Instantiate(clock);
        float set = Random.Range(-screenArea.x, screenArea.x);
        obj.transform.position = new Vector3(set, screenArea.y * -3f, -0.1f);
    }

    IEnumerator clockSpawns()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5.0f, 10.0f));
            SpawnClock();

        }
    }
}

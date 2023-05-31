using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float lastSpawn;
    public float now;
    public float delay = 5f;

    void Start()
    {
        lastSpawn = -delay;
        now = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && lastSpawn + delay <= now)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            Debug.Log("Spawnato");
            lastSpawn = now;
        }
        else
        {
            Debug.Log("Non puoi far spawnare cani perchè è passato troppo poco tempo dall'ultimo spawn");
        }
        now += 1.0f * Time.deltaTime;
    }
}

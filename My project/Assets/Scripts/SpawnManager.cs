using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    enum SpawnModes
    {
        FromTheTop = 0,
        FromTheLeft = 1,
        FromTheRight = 2
    };

    public GameObject[] animalPrefabs;
    private float spawnRange = 20;
    private float startDelay = 2f;
    private float spawnInterval = 2.5f;
    
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomAnimal()
    {
        
        
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        int spawnMode = Random.Range(0, 3);
        SpawnModes choosenMode = (SpawnModes)spawnMode;
        Vector3 spawnPos = new Vector3(0,0,0);
        Quaternion spawnRot = Quaternion.Euler(0,0,0);

        switch(choosenMode)
        {
            case SpawnModes.FromTheTop:
                spawnPos = new Vector3(Random.Range(-spawnRange, spawnRange), 0, spawnRange);
                break;
            case SpawnModes.FromTheLeft:
                spawnPos = new Vector3(-spawnRange, 0, Random.Range(-spawnRange, spawnRange));
                spawnRot = Quaternion.Euler(0,-90,0);
                break;
            case SpawnModes.FromTheRight:
                spawnPos = new Vector3(spawnRange, 0, Random.Range(-spawnRange, spawnRange));
                spawnRot = Quaternion.Euler(0,90,0);
                break;
        }

        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation * spawnRot);
    }

}

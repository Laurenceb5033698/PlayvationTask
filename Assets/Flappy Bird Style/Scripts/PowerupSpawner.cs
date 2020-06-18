using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    
    public GameObject[] PowerupPrefabs; //list of powerups

    public float spawnRate = 3f;
    public float heightMin = -1f;
    public float heightMax = 3.5f;

    private float timeSinceLastSpawned;

    void Start()
    {
        //check if powerups are attached
        if (PowerupPrefabs.Length == 0)
            //disable spawner
            enabled = false;
    }



    void Update()
    {
        //timing
        timeSinceLastSpawned += Time.deltaTime;

        if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0f;

            //Set a random y position for the column
            float spawnYPosition = Random.Range(heightMin, heightMax);
            //choose x position from between fixed range
            float spawnXPosition = Random.Range(8, 12);

            Vector3 SpawnPos = new Vector3(spawnXPosition, spawnYPosition, 0);

            //random type
            int type = Random.Range(0, PowerupPrefabs.Length);

            //spawn powerup
            Instantiate(PowerupPrefabs[type], SpawnPos, Quaternion.identity);
        }
    }
}

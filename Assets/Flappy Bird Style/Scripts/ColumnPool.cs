﻿using UnityEngine;
using System.Collections;

public class ColumnPool : MonoBehaviour 
{
	public GameObject[] columnPrefabs;									//The column game object.
	public int columnPoolSize = 5;									//How many columns to keep on standby.
	public float spawnRate = 3f;									//How quickly columns spawn.
	public float columnMin = -1f;									//Minimum y value of the column position.
	public float columnMax = 3.5f;									//Maximum y value of the column position.

	private GameObject[] columns;									//Collection of pooled columns.
	private int currentColumn = 0;									//Index of the current column in the collection.

	private Vector2 objectPoolPosition = new Vector2 (-15,-25);		//A holding position for our unused columns offscreen.
	private float spawnXPosition = 10f;

	private float timeSinceLastSpawned;


	void Start()
	{
		timeSinceLastSpawned = 0f;

		//Initialize the columns collection.
		columns = new GameObject[columnPoolSize];
		//Loop through the collection... 
		for(int i = 0; i < columnPoolSize; i++)
		{
			//...and create the individual columns.
			columns[i] = (GameObject)Instantiate(columnPrefabs[0], objectPoolPosition, Quaternion.identity);
		}
	}


	//This spawns columns as long as the game is not over.
	void Update()
	{
		timeSinceLastSpawned += Time.deltaTime;

		if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate) 
		{	
			timeSinceLastSpawned = 0f;

			//Set a random y position for the column
			float spawnYPosition = Random.Range(columnMin, columnMax);

            RandomColumnType();

            //...then set the current column to that position.
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);

			//Increase the value of currentColumn. If the new size is too big, set it back to zero
			currentColumn ++;

			if (currentColumn >= columnPoolSize) 
			{
				currentColumn = 0;
			}
		}
	}


    void RandomColumnType()
    {
        if (columnPrefabs.Length > 1)
        {
            //25% chance to spawn different column type
            if (Random.Range(0, 100) < 25)
            {
                int index = Random.Range(1, columnPrefabs.Length);
                Destroy(columns[currentColumn]);
                columns[currentColumn] = (GameObject)Instantiate(columnPrefabs[index], objectPoolPosition, Quaternion.identity);
            }
            else
            {
                Destroy(columns[currentColumn]);
                columns[currentColumn] = (GameObject)Instantiate(columnPrefabs[0], objectPoolPosition, Quaternion.identity);
            }
        }
    }

    //when scroll speed increases, must decrease column spawn rate to keep up
    public void AlterSpawnrate()
    {
        //minimum spawn rate of 1s
        if (spawnRate > 0.8f)
        {
            spawnRate -= 0.25f;
        }
    }
}
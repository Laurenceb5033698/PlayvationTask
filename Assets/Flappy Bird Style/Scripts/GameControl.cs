﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour 
{
	public static GameControl instance;			//A reference to our game control script so we can access it statically.
	public Text scoreText;						//A reference to the UI text component that displays the player's score.
	public GameObject gameOvertext;				//A reference to the object that displays the text which appears when the player dies.
    public GameObject Bird; //refernce to Bird

	private int score = 0;						//The player's score.
	public bool gameOver = false;				//Is the game over?
	public float scrollSpeed = -1.5f;


    public float SpeedIncrease = -0.2f;         //speed incrase as points are scored

	void Awake()
	{
		//If we don't currently have a game control...
		if (instance == null)
			//...set this one to be it...
			instance = this;
		//...otherwise...
		else if(instance != this)
			//...destroy this one because it is a duplicate.
			Destroy (gameObject);
	}

	void Update()
	{
		//If the game is over and the player has pressed some input...
		if (gameOver && Input.GetMouseButtonDown(0)) 
		{
			//...reload the current scene.
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	public void BirdScored()
	{
		//The bird can't score if the game is over.
		if (gameOver)	
			return;
		//If the game is not over, increase the score...
		score++;
		//...and adjust the score text.
		scoreText.text = "Score: " + score.ToString();

        //when Points are scored try speed up game
        SpeedUpGame();


    }

    public void SpeedUpGame()
    {
        //make score increase scroll speed
        if (score % 2 == 0)
        {
            scrollSpeed += SpeedIncrease;
            GetComponent<ColumnPool>().AlterSpawnrate();
        }
    }

	public void BirdDied()
	{
		//Activate the game over text.
		gameOvertext.SetActive (true);
		//Set the game to be over.
		gameOver = true;
	}
}

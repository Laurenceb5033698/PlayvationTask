using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private string GameScene;      //name of game scene



    //functions for Button to connect to
    public void PlayButtonPressed()
    {
        //load game scene
        SceneManager.LoadScene(GameScene);

    }

    public void QuitButtonPressed()
    {
        //Quit game
        Application.Quit();

    }
}

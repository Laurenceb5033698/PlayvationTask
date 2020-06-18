using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private string TitleScene;     //name of Menu Scene


    //functions for Button to connect to
    public void RetryButtonPressed()
    {
        //reload current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    public void ReturnToMenuButtonPressed()
    {
        //quit to menu
        SceneManager.LoadScene(TitleScene);

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{

    //different types
    public enum PowerupType { SpeedUp, Heavy };

    public PowerupType Type;


    void OnTriggerEnter2D(Collider2D other)
    {
        //check if player triggered
        if (other.GetComponent<Bird>() != null)
        {
            //apply powerup and remove powerup
            ApplyPowerup(other.gameObject);
            Destroy(gameObject);
        }
    }


    private void ApplyPowerup(GameObject bird)
    {
        switch (Type)
        {
            case PowerupType.Heavy:
                //add score, but bird gravity increased
                GameControl.instance.BirdScored();
                bird.GetComponent<Rigidbody2D>().gravityScale += 0.1f;
                break;
            case PowerupType.SpeedUp:
            default://speedup
                GameControl.instance.SpeedUpGame();
                break;

        }
    }
}

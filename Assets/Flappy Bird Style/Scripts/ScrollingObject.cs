using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour 
{
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () 
	{
		//Get and store a reference to the Rigidbody2D attached to this GameObject.
		rb2d = GetComponent<Rigidbody2D>();

        //Start the object moving.
        Vector2 old = rb2d.velocity;
        old.x = GameControl.instance.scrollSpeed;
        rb2d.velocity = old;
        
	}

	void Update()
	{
        // If the game is over, stop scrolling.
        if (GameControl.instance.gameOver == true)
        {
            rb2d.velocity = Vector2.zero;
        }
        else
        {
            //check if the speed has increased
            if (GameControl.instance.scrollSpeed != rb2d.velocity.x)
            {   //apply the new speed
                //get old velocity
                Vector2 old = rb2d.velocity;
                //change x value, but preserve y speed
                old.x = GameControl.instance.scrollSpeed;
                //re-apply
                rb2d.velocity = old;

            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBackground : MonoBehaviour
{

    //simple Scrolling object script for title screen background, does not require GameControl instance
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-1.5f, 0);
    }
    
}

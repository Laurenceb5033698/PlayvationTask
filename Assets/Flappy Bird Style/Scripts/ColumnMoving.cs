using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnMoving : Column
{
    public float MinPos = -1.0f;
    public float MaxPos = 3.5f;
    public float verticalSpeed = 1.0f;

    bool ascending;

    private void Start()
    {
        //randomly determine direction
        ascending = Random.Range(0, 1) == 1;
        //set in motion at start
        VerticalMotion();
    }

    private void Update()
    {
        //if outisde of range
        if (transform.position.y < MinPos || transform.position.y > MaxPos)
        {
            VerticalMotion();
        }
    }


    void VerticalMotion()
    {
        Debug.Log("applying vertical motion");
        Vector2 old = gameObject.GetComponent<Rigidbody2D>().velocity;
        if (ascending && old.y >= 0)
        {
            Debug.Log("ascending");
            old.y = -verticalSpeed;                                          //change y value, but preserve x speed
            gameObject.GetComponent<Rigidbody2D>().velocity = old;          //re-apply
            ascending = !ascending;
        }
        else
        {
            if (old.y <= 0)
            { //decend
                Debug.Log("decending");
                old.y = verticalSpeed;
                gameObject.GetComponent<Rigidbody2D>().velocity = old;
                ascending = !ascending;
            }
        }
    }

}

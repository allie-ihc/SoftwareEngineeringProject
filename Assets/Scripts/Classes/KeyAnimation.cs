using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAnimation 
{
    public GameObject key;
    public bool movingDown;
    public Vector3 topPos;
    public Vector3 bottomPos;
    public float speed;
    public float distance;
    public bool moving;

    public KeyAnimation(GameObject k)
    {
        distance = .5f;
        speed = 5f;
        this.key = k;
        topPos = k.transform.position;
        bottomPos = k.transform.position;
        bottomPos.y = bottomPos.y-distance;
        movingDown = false;
        moving = false;
    }
    public void move()
    {
        if (movingDown)
        {
            key.transform.position = Vector3.MoveTowards(key.transform.position, bottomPos, speed*Time.deltaTime);
            if(key.transform.position == bottomPos)
            {
                moving = false;
            }
        }
        else
        {
            key.transform.position = Vector3.MoveTowards(key.transform.position, topPos, speed * Time.deltaTime);
            if (key.transform.position == topPos)
            {
                moving = false;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AkeyController : MonoBehaviour
{
    // Start is called before the first frame update
    KeyAnimation A;
    public KeyCode key;
    void Start()
    {
        A = new KeyAnimation(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            A.movingDown = true;
            A.moving=true;
            A.move();
        }
        if (Input.GetKeyUp(key))
        {
            A.movingDown = false;
            A.moving = true;
            A.move();
        }
        A.move();
    }
}

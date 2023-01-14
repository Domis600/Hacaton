using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPlatform2 : MonoBehaviour
{
    float dirX;
    float speed = 3f;

    bool moveingRight = true;

    void Update()
    {
        if (transform.position.x < 22f)
        {
            moveingRight = true;
        }
        else if (transform.position.x > 29f)
        {
            moveingRight = false;
        }

        if (moveingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x + -speed * Time.deltaTime, transform.position.y);
        }
    }
}
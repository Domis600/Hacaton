using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPlatform : MonoBehaviour
{
    float dirX;
    float speed = 3f;

    bool moveingRight = false;

    void Update()
    {
        if (transform.position.x < 12f)
        {
            moveingRight = true;
        }
        else if (transform.position.x > 19f)
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

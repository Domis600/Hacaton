using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlstform : MonoBehaviour
{
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("DropPlatform", 0.1f);
            Destroy(gameObject, 5f);
        }
    }

    void DropPlatform()
    {
        rb.isKinematic = false;
    }
}

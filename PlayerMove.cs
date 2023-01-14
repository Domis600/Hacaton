using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour

{
    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer sr;
    public Vector2 moveVector;
    public float speed = 2f;
    public bool faceRight = true;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        walk();
        Reflect();
        Jump();
        CheckingGround();
        dash();

        if(transform.position.y < -45)
        {
            Destroy(gameObject);
        }
    }

    void walk()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);

    }

    void Reflect()
    {
        if ((moveVector.x > 0 && !faceRight) || (moveVector.x < 0 && faceRight))
        {
            transform.localScale *= new Vector2(-1, 1);
            faceRight = !faceRight;
        }
    }

    public float jumpForce = 7f;
    

    void Jump()
    {

        if (Input.GetKeyDown(KeyCode.S))
        {
            Physics2D.IgnoreLayerCollision(7, 8, true);
            Invoke("IgnoreLayerOff", 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.W) && onGround)
        {
            anim.StopPlayback();
            anim.Play("jump");
            rb.velocity = new Vector2(0, jumpForce);
        }
    }

    void IgnoreLayerOff()
    {
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }


    public bool onGround;
    public Transform GroundCheck;
    public float checkRadius = 0.07f;
    public LayerMask Ground;

    void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
        anim.SetBool("onGround", onGround);
    }

    public int DashImpulse = 5000;

    void dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && !lockdash)
        {
            lockdash = true;
            Invoke("dashlock", 2f);

            anim.StopPlayback();
            anim.Play("dash");

            rb.velocity = new Vector2(0, 0);

            if (!faceRight) { rb.AddForce(Vector2.left * DashImpulse); }
            else { rb.AddForce(Vector2.right * DashImpulse); }
        }
    }

    private bool lockdash = false;

    void dashlock()
    {
        lockdash = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals ("tiles"))
        {
            this.transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("tiles"))
        {
            this.transform.parent = null;
        }
    }

   



}

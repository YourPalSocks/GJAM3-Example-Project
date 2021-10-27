using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Rigidbody2D rbody;
    private SpriteRenderer spr;
    private Vector2 vel;
    private Collider2D col;

    public int speed = 5;
    public float jumpPower = 5;
    private float distToGround;
    public bool canMove = true;



    void Start()
    {
        //Get Components
        rbody = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();

        distToGround = col.bounds.extents.y;
    }

    void Update()
    {
        //Disable Movement if needed
        if (!canMove)
        {
            rbody.velocity = Vector2.zero;
            return;
        }

        //Movement
        float x = Input.GetAxisRaw("Horizontal");

        //Sprinting
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 8;
        }
        else 
        {
            speed = 5;
        }

        vel = new Vector2(x * speed, rbody.velocity.y);


        //Start the jump
        if (Input.GetKey(KeyCode.Space) && isGrounded())
        {
            
            rbody.AddForce(Vector3.up * 50 * jumpPower);
        }

        rbody.velocity = vel;


        //Flip sprite for negative
        if (x < 0)
        {
            spr.flipX = true;
        }
        else if (x > 0)
        {
            spr.flipX = false;
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, distToGround + 0.1f);
        if (hit.collider && hit.collider != col)
        {
            return true;
        }
        return false;
    }
}

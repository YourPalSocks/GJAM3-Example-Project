using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Rigidbody2D rbody;
    private SpriteRenderer spr;
    private Vector3 vel;
    private Collider2D col;

    [SerializeField] private int speed = 5;
    private readonly int STARTING_JUMP_POWER = 2;
    private readonly int FINAL_JUMP_POWER = 6;
    [SerializeField] private float jumpPower = 3;
    private float distToGround;

    private bool jumpKeyLetGo = false;


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

        //Movement
        float x = Input.GetAxisRaw("Horizontal");
        vel = new Vector2(x * speed, rbody.velocity.y);

        //Dynamic jump power
        if (Input.GetKey(KeyCode.Space) && jumpPower < FINAL_JUMP_POWER && !jumpKeyLetGo)
        {
            vel.y = jumpPower;
            jumpPower += 0.5f;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            jumpKeyLetGo = true;
        }

        if (isGrounded())
        {
            jumpPower = STARTING_JUMP_POWER;
            jumpKeyLetGo = false;
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

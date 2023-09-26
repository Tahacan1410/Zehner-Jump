using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    Rigidbody2D player;
    Animator anim;
    SpriteRenderer sprite;

    BoxCollider2D coll;

    [SerializeField] private LayerMask jumpableGround;

    private float playerSpeed = 7f;
    private float playerJumpForce = 14f;
    private float xAxis = 0f;

    private enum PlayerMovementState{idle, running, jumping, falling}

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        
        
    }

    // Update is called once per frame
    void Update()
    {   

        xAxis = Input.GetAxisRaw("Horizontal");
        player.velocity = new Vector2(xAxis*playerSpeed, player.velocity.y);
       
        
        if(Input.GetButtonDown("Jump") && PlayerGrounded())
        {   
            player.velocity = new Vector2(player.velocity.x, playerJumpForce);
        }

        UpdateAnimState();

    }

    private void UpdateAnimState()
    {   
        PlayerMovementState state;

        if(xAxis>0f)
        {
            state = PlayerMovementState.running;
            sprite.flipX = false;
        }

        else if (xAxis<0f)
        {
            state = PlayerMovementState.running;
            sprite.flipX = true;
        }

        else
        {
            state = PlayerMovementState.idle;
        }

        if(player.velocity.y > .1f)
        {
            state = PlayerMovementState.jumping;
        }

        else if(player.velocity.y < - .1f)
        {
            state = PlayerMovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool PlayerGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}

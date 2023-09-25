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

    private float playerSpeed = 7f;
    private float playerJumpForce = 14f;

    private float xAxis = 0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        
        
    }

    // Update is called once per frame
    void Update()
    {   

        xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Jump");
        player.velocity = new Vector2(xAxis*playerSpeed, player.velocity.y);
       
        
        if(Input.GetButtonDown("Jump"))
        {   
            player.velocity = new Vector2(player.velocity.x, playerJumpForce);
        }

        if(yAxis>0f)
        {   
            anim.SetBool("jumping", true);
        }

        else
        {
            anim.SetBool("jumping", false);
        }



        if(xAxis>0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = false;
        }

        else if (xAxis<0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = true;
        }

        else
        {
            anim.SetBool("running", false);
        }
    }




        


}

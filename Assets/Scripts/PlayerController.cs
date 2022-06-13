using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float JumpForce = 20f;
    public bool jump;
    public Rigidbody2D rb;
    bool facingRight = true;


    void Update()
    {
        float MoveX = Input.GetAxisRaw("Horizontal");
        float MoveY = Input.GetAxisRaw("Vertical");
    
        if(MoveX!=0)
        {
        rb.velocity = new Vector2(MoveSpeed * MoveX, rb.velocity.y);
        }
        if(MoveY==1 && !jump)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce * MoveY);
            jump = true;
        }
        if(MoveX<0 && facingRight) //If player is moving left and facing right, player will flip left
        {
            flip();
        }
        if(MoveX>0 && !facingRight) // If player is moving right and not facing right, player will flip right
        {
            flip();
        }
    }

    void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(new Vector3(0, 180, 0));

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        jump = false;
    }

}

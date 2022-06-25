using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float JumpForce = 20f;
    public bool jump;
    public Rigidbody2D rb;

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
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        jump = false;
    }

}

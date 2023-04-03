using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float movespeed = 10f;
    public Rigidbody2D rb;
    float playerJump = 5f;

    bool jump = false;
    public Animator playerAnimater;
    Vector2 vector2Move;
    public SpriteRenderer sp;

    public void FixedUpdate()
    {
        PlayerJump();
        setAnimation();
        PlayerMove();
        FilpPlayer();

    }

    public void PlayerMove()
    {
        vector2Move = new Vector2(Input.GetAxis("Horizontal"), 0f);
        transform.Translate(vector2Move * movespeed * Time.deltaTime);
    }

    public void PlayerJump()
    {
         if (Input.GetKeyDown(KeyCode.Space) && jump == false)
         {
            jump = true;
            playerAnimater.SetBool("Jump", true);
            rb.velocity = Vector2.up * playerJump;
         }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            jump = false;
            playerAnimater.SetBool("Jump", false);
            Debug.Log(jump);
        }
    }

    void setAnimation()
    {
        if (vector2Move.x == 0)
        {
            playerAnimater.SetBool("move", false);
        }

        if (vector2Move.x > 0 || vector2Move.x < 0)
        {
            playerAnimater.SetBool("move", true);

        }
    }
        void FilpPlayer()
        {
            if(vector2Move.x < -0.1f)
            {
                sp.flipX = true;
            }
            if (vector2Move.x > 0.1f)
            {
                sp.flipX = false;
            }
        }
}

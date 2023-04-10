using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroScript : MonoBehaviour
{
    private float movespeed = 10f;
    public Rigidbody2D rb;
    float playerJump = 8f;

    bool jump = false;
    public Animator playerAnimater;
    Vector2 vector2Move;

    public void FixedUpdate()
    {
        PlayerJump();
        setMoveAnimation();
        PlayerMove();
    }

    private void Update()
    {
        FilpPlayer();
        playerAttack();
    }

    public void PlayerMove()
    {
        vector2Move = new Vector2(Input.GetAxis("Horizontal"),0f);
        transform.Translate((vector2Move * movespeed * Time.deltaTime).x, 0f, 0f);
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
        }
    }

    void setMoveAnimation()
    {
        if (vector2Move.x == 0)
        {
            playerAnimater.SetBool("move", false);
        }

        if (vector2Move.x > 0 || vector2Move.x < 0)
        {
            rollPlayer();
            playerAnimater.SetBool("move", true);

        }
    }

    void FilpPlayer()
    {
        if (vector2Move.x < -0.1f)
        {
            transform.localScale = new Vector2(-1.371398f, 1.371398f);
        }
        if (vector2Move.x > 0.1f)
        {
            transform.localScale = new Vector2(1.371398f, 1.371398f);
        }
    }

    void rollPlayer()
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            playerAnimater.SetBool("roll", true);
        }
        else
        {
            playerAnimater.SetBool("roll", false);
        }
    }

    void playerAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerAnimater.SetTrigger("attack");
        }
    }
}

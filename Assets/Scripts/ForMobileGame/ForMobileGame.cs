using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForMobileGame : MonoBehaviour
{
    public Joystick fixedJoystick;
    public GameObject Hero;
    float MovementSpeed = 5f;
    Vector2 direction;
    public Animator playerAnimater;
    public Rigidbody2D heroRb;


    float playerJump = 8f;
    bool jump = false;

    void MovePlayerWithJoyStick()
    {
        float horizontalDirection = fixedJoystick.Horizontal;
        float verticalDirection = fixedJoystick.Vertical;


        direction = new Vector2(horizontalDirection, verticalDirection);

        Hero.transform.Translate((direction * Time.deltaTime * MovementSpeed).x, 0f, 0f);
    }

    private void Update()
    {
        MovePlayerWithJoyStick();
        setMoveAnimation();
        flipPlayer();
    }
    
    void setMoveAnimation()
    {
        if (direction.x == 0)
        {
            playerAnimater.SetBool("move", false);
            playerAnimater.SetBool("roll", false);
        }

        if (direction.x > 0 || direction.x < 0)
        {
            rollPlayer();
            playerAnimater.SetBool("move", true);

        }
    }
    void flipPlayer()
    {
        if (direction.x < -0.1f)
        {
            Hero.transform.localScale = new Vector2(-1.371398f, 1.371398f);
        }
        if (direction.x > 0.1f)
        {
            Hero.transform.localScale = new Vector2(1.371398f, 1.371398f);
        }
    }

    void rollPlayer()
    {
        if (direction.y < -0.1f)
        {
            playerAnimater.SetBool("roll", true);
        }
        else
        {
            playerAnimater.SetBool("roll", false);
        }
    }

    public void PlayerJump()
    {
        if (jump == false)
        {
            jump = true;
            playerAnimater.SetBool("Jump", true);
            heroRb.velocity = Vector2.up * playerJump;
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

     public void playerAttack()
    { 
        playerAnimater.SetTrigger("attack");
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform hero;
    public Animator an;
    public SpriteRenderer sp;
    public float speed = 10f;
    Rigidbody2D rb;
    bool trigger = true;

    private void Start()
    {
        hero = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Enemymove()
    {
        float dir = hero.position.x - transform.position.x;
        float dirY = hero.position.y - transform.position.y;

        if (Mathf.Abs(dir) < 6f && Mathf.Abs(dirY) < 1.1f)
        {
            rb.velocity = dir * Vector2.right * speed * Time.deltaTime;
            an.SetBool("followPlayer", true);
        }
        else 
        {
            an.SetBool("followPlayer", false);
        }

        if (Mathf.Abs(dir) < 2f && Mathf.Abs(dirY) < 1.1f)
        {
            if (trigger == true)
            {
                trigger = false;
                StartCoroutine(Attacking());
            }
            rb.velocity = Vector2.zero;
            an.SetBool("followPlayer", false);

        }
    }

    void flipPlayer()
    {
        if (rb.velocity.x < -0.1f)
        {
            sp.flipX = true;
        }
        else if (rb.velocity.x > 0.1f)
        {
            sp.flipX = false;
        }
    }

    IEnumerator Attacking()
    {
        an.SetTrigger("attackHero");
        yield return new WaitForSeconds(1);
        trigger = true;
    }

    private void FixedUpdate()
    {
        Enemymove();
        flipPlayer();
    }
}

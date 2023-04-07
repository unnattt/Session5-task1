using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnenyAttackHeroScript : MonoBehaviour
{
    public Animator an;
    bool ishitting = false;
    float health = 3;
    public GameObject hero;
    public Rigidbody2D rb;
    bool flag = true;
    public GameObject Panel;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && ishitting == true)
        {  
            ishitting = false;
            health -= 1;
            an.SetTrigger("HurtbyEnemy");
        }
    }
    void Death()
    {
        if(health == 0)
        {
            if( flag == true)
            {
                flag = false;
                StartCoroutine(DeathAnim());
            }

            rb.bodyType = RigidbodyType2D.Static;
            an.SetBool("Alive", false);
            Destroy(hero,1);
            Panel.SetActive(true);

        }
    }
    private void Update()
    {
        Death();
    }

    IEnumerator DeathAnim()
    {
        an.SetTrigger("HeroDeath");
        yield return new WaitForSeconds(3);
        flag = true;
    }

    public void hitOn()
    {
        ishitting = true;
    }
    public void hitOff()
    {
        ishitting = false;
    }
}

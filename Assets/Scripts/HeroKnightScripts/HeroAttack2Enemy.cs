using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack2Enemy : MonoBehaviour
{
    public Animator an;
    public GameObject eneny;
    bool ishitting = false;
    float health = 3;
    bool flag = true;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy2" && ishitting == true)
        {
            ishitting = false;
            health -= 1;
            an.SetTrigger("HitbyHero");
        }
    }

    void Death()
    {
        if (health == 0)
        {
            if (flag == true)
            {
                flag = false;
                StartCoroutine(DeathAnim());
            }
            an.SetBool("Alive", false);
            Destroy(eneny, 1);
        }
    }

    IEnumerator DeathAnim()
    {
        an.SetTrigger("EnemyDeath");
        yield return new WaitForSeconds(3);
        flag = true;
    }

    private void Update()
    {
        Death();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackTriggerScript : MonoBehaviour
{
    public Animator an;
    bool ishitting = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy" && ishitting == true)   
        {
            an.SetTrigger("HitbyHero");
        }
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


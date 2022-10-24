using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator anim;
    int hit;
    public GameObject quest;
    Quest questKill;

    private void Start()
    {
       questKill = quest.GetComponent<Quest>();
    }
    public void Kill()
    {
        hit++;
        if (hit == 3)
        {
            questKill.EnemyKill();
            Destroy(gameObject);
        }
        else
        {
            anim = GetComponent<Animator>();
            anim.SetTrigger("ReceivePunch");
        }
        
    }
}

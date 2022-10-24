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
        anim = GetComponent<Animator>();
        questKill = quest.GetComponent<Quest>();
    }
    public void Kill()
    {
        hit++;
        if (hit == 3)
        {
            anim.SetBool("Death", true);
            questKill.EnemyKill();
            GetComponent<CapsuleCollider>().enabled = false;
            Invoke("DestroyModel", 3);
        }
        else
        {
            
            anim.SetTrigger("ReceivePunch");
        }
        
    }

    private void DestroyModel()
    {
        Destroy(gameObject);
    }
}

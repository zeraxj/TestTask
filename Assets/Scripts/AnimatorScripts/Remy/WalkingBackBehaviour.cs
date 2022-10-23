using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkingBackBehaviour : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform enemyStartPoint;

    Transform player;
    float chaseRange = 10;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemyStartPoint = GameObject.FindGameObjectWithTag("EnemyStartPoint").transform;
        agent = animator.GetComponent<NavMeshAgent>();

        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(enemyStartPoint.position);

        float distance = Vector3.Distance(animator.transform.position, player.position);
        float distance2 = Vector3.Distance(animator.transform.position, enemyStartPoint.position);

        if (distance < chaseRange)
        {
            animator.SetBool("isChasing", true);
        }
        if (distance2 < 0.5)
        {
            animator.SetBool("isWalking", false);
            animator.transform.LookAt(player);
        }
    }

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }


}

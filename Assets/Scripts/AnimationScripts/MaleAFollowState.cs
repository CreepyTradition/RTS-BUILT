using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MaleAFollowState : StateMachineBehaviour
{
    AttackController attackController;

    NavMeshAgent agent;
    public float attackingDistance = 1f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        attackController = animator.transform.GetComponent<AttackController>();
        agent = animator.transform.GetComponent<NavMeshAgent>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Idle State?
        if (attackController.targetToAttack == null)
        {
            animator.SetBool("IsFollowing", false);
        }
        else
        {
            if (animator.transform.GetComponent<UnitMovement>().isCommandedToMove == false)
            {
                agent.SetDestination(attackController.targetToAttack.position);
                animator.transform.LookAt(attackController.targetToAttack);
            }



        }


        // Moving towards target

        // Attack State?
        float distanceFromTarget = Vector3.Distance(attackController.targetToAttack.position, animator.transform.position);
        if (distanceFromTarget < attackingDistance)
        {
            agent.SetDestination(animator.transform.position);
            animator.SetBool("IsAttacking", true);
        }
    }
}

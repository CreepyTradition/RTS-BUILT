using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaleAIdleState : StateMachineBehaviour
{
    AttackController attackController;

    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        attackController = animator.transform.GetComponent<AttackController>();
    }

    // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (attackController.targetToAttack != null)
        {
            animator.SetBool("IsFollowing", true);
        }
    }
}

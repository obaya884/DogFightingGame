using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackBehavior : StateMachineBehaviour
{
    float onStateEnterSpeed;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        onStateEnterSpeed = animator.GetComponent<PlayerManager>().moveSpeed;
        animator.GetComponent<PlayerManager>().moveSpeed = 0;
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<PlayerManager>().moveSpeed = onStateEnterSpeed;
    }
}

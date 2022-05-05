using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtBehavior : StateMachineBehaviour
{
    float onStateEnterSpeed;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Hurt");
        onStateEnterSpeed = animator.GetComponent<PlayerManager>().moveSpeed;
        animator.GetComponent<PlayerManager>().moveSpeed = 0.5f;
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<PlayerManager>().moveSpeed = onStateEnterSpeed;
        animator.ResetTrigger("Hurt");
    }

}

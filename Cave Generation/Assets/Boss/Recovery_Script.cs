using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recovery_Script : StateMachineBehaviour
{
    public float recoveryTime;
    float timeCheck;
    BossRoom boss;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = animator.GetComponent<BossRoom>();
        timeCheck = recoveryTime;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timeCheck = Mathf.Clamp(timeCheck - Time.deltaTime, 0, recoveryTime);
        if (timeCheck <= 0)
        {
            timeCheck = recoveryTime;
         float rand= Random.Range(0f,1f);
            Debug.Log(rand);
            if(rand <= 0.5f )
            {
                animator.SetTrigger("AttackOne");
            }
            else
            {
                animator.SetTrigger("AttackTwo");
            }
        }
    }

     //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.ChangeState();
    }

}

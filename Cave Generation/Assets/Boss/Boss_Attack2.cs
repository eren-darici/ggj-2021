using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Attack2 : StateMachineBehaviour
{
    Transform player;
    BossRoom bossObj;

    public float rateOfFire;
    float timeCheck;

    public float burstTime;
    float burstCheck;
     //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        bossObj = animator.GetComponent<BossRoom>();
        burstCheck = burstTime;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timeCheck = Mathf.Clamp(timeCheck - Time.deltaTime, 0, rateOfFire);
        burstCheck = Mathf.Clamp(burstCheck - Time.deltaTime, 0, burstTime);
        if (timeCheck <= 0)
        {
            foreach (Transform i in bossObj.attack2)
            {
                bossObj.Fire(i);
                timeCheck = rateOfFire;
            }
        }
        if(burstCheck <= 0)
        {
            animator.SetTrigger("Wait");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossObj.ChangeState();
    }

   
}

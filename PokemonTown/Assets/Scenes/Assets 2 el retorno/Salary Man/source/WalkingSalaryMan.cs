using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSalaryMan : StateMachineBehaviour
{
    private GoToTarget salaryMan;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        salaryMan = animator.gameObject.GetComponent<GoToTarget>();
        salaryMan.NewPos();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector3.Distance(salaryMan.target.position, salaryMan.transform.position) < salaryMan.targetRadius)
        {
            //animator.SetBool("IsIdle", true);
            animator.gameObject.GetComponent<SalaryMan>().Stop();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldManWandSearch : StateMachineBehaviour
{
    private OldManWalk ODwalk;
    private OldManBlackBoard ODBlackBoard;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ODwalk = animator.GetComponent<OldManWalk>();
        //ODwalk.SetRandPostion();
        ODBlackBoard = animator.GetComponent<OldManBlackBoard>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ODwalk.SetRandPostion();
        foreach (GameObject bench in ODBlackBoard.Benches)
            if (Vector3.Distance(ODwalk.transform.position, bench.transform.position) <= ODBlackBoard.DistBench)
            {
                ODBlackBoard.target = bench;
                animator.SetTrigger("serch");
                Debug.Log(ODBlackBoard.target.ToString());
                break;
            }


        //Debug.Log("aaaaaaaa");

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}

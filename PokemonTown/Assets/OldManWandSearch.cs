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


       

    }

    
}

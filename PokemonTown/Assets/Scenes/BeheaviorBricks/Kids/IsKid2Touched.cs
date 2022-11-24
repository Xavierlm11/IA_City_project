using UnityEngine;
 
using Pada1.BBCore;
using Pada1.BBCore.Framework;
using UnityEngine.AI;
[Condition("MyConditions/Is Kid2 touched?")]
[Help("Checks is the kid has being touched by the other.")]
public class IsKid2Touched : ConditionBase
{
    [InParam("user")]
    [SerializeField]
    private GameObject user;

    [InParam("OtherKid")]
    [SerializeField]
    private GameObject OtherKid1;

    [InParam("CanFollow")]
    [SerializeField]
    private bool CanFoll;

    // private Kid1Blackboard K1B ;

    //private Kid2Blackboard K2B;
    public override bool Check()
    {
        //Animator a ;
       // K1B = a.GetComponent<Kid1Blackboard>();
        // GameObject kid1 = GameObject.Find("kid1");
        // GameObject OtherKid = GameObject.Find("OtherKid2");
        bool touch = false;
        

       if( (Vector3.Distance(user.transform.position, OtherKid1.transform.position) < 3f) /*&& !user.GetComponent<Kid2Blackboard>()._CanTouched*/)
        {
            touch = true;
            user.GetComponent<Kid2Blackboard>()._CanTouched = touch;
            //OtherKid1.GetComponent<Kid1Blackboard>()._IsTouched = false;

        }
        CanFoll = touch;
        //Debug.Log("aaaaaaa");

        return touch;

    }
} 

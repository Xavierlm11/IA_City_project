using UnityEngine;
 
using Pada1.BBCore;
using Pada1.BBCore.Framework;
using UnityEngine.AI;
[Condition("MyConditions/Is Kid1 touched?")]
[Help("Checks is the kid has being touched by the other.")]
public class IsKid1Touched : ConditionBase
{
    [InParam("user")]
    [SerializeField]
    private GameObject user;

    [InParam("OtherKid")]
    [SerializeField]
    private GameObject OtherKid2;

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


       if( (Vector3.Distance(user.transform.position, OtherKid2.transform.position) < 3f) && ! user.GetComponent<Kid1Blackboard>()._CanTouched )
        {
            touch = true;
            user.GetComponent< Kid1Blackboard >()._CanTouched = touch;
            //user.GetComponent<Kid1Blackboard>()._IsTouched = false;
            //OtherKid2.SendMessage()
            // OtherKid2.GetComponent<Kid2Blackboard>()._IsTouched = false;
        }

        CanFoll = touch;

       // Debug.Log("aaaaaaa");

        return touch;

    }
} 

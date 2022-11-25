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

    
    public override bool Check()
    {
        
        bool touch = false;


       if( (Vector3.Distance(user.transform.position, OtherKid2.transform.position) < 3f) && OtherKid2.GetComponent<Kid2Blackboard>()._CanTouched)
        {
            touch = true;
           // user.GetComponent< Kid1Blackboard >()._CanTouched = touch;

            OtherKid2.SendMessage("CantTouch");
            user.GetComponent<Kid1Blackboard>().Stop();
            //user.GetComponent<Kid1Blackboard>()._IsTouched = false;
            //OtherKid2.SendMessage()
            // OtherKid2.GetComponent<Kid2Blackboard>()._IsTouched = false;
        }

        CanFoll = touch;


        return touch;

    }
} 

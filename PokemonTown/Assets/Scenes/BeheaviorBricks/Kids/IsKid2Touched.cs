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

    
    public override bool Check()
    {
       
        bool touch = false;
        

       if( (Vector3.Distance(user.transform.position, OtherKid1.transform.position) < 3f) && OtherKid1.GetComponent<Kid1Blackboard>()._CanTouched)
        {
            touch = true;
          
            OtherKid1.SendMessage("CantTouch");
            user.GetComponent<Kid2Blackboard>().Stop();
          

        }
        CanFoll = touch;
        

        return touch;

    }
} 

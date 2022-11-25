using UnityEngine;
 
using Pada1.BBCore;
using Pada1.BBCore.Framework;
using UnityEngine.AI;
[Condition("MyConditions/Can be touched?")]
[Help("Checks is the kid has being touched by the other.")]
public class CanBeTouched : ConditionBase
{
    [InParam("CanFollow")]
    [SerializeField]
    private bool CanFoll;

    [InParam("OtherKid")]
    [SerializeField]
    private GameObject other;

    [InParam("User")]
    [SerializeField]
    private GameObject user1;
 
    public override bool Check()
    {
 
        if (user1.name=="Kid1")
        {
            if (other.GetComponent<Kid2Blackboard>()._CanTouched && user1.GetComponent<Kid1Blackboard>()._CanTouched
               || !other.GetComponent<Kid2Blackboard>()._CanTouched && !user1.GetComponent<Kid1Blackboard>()._CanTouched
               || other.GetComponent<Kid2Blackboard>()._CanTouched && !user1.GetComponent<Kid1Blackboard>()._CanTouched)
            {
                CanFoll = false;
            }
            else
            {
            CanFoll = user1.GetComponent<Kid1Blackboard>()._CanTouched;

            }
        }
        if (user1.name == "Kid2")
        {
            if (other.GetComponent<Kid1Blackboard>()._CanTouched && user1.GetComponent<Kid2Blackboard>()._CanTouched
               || !other.GetComponent<Kid1Blackboard>()._CanTouched && !user1.GetComponent<Kid2Blackboard>()._CanTouched
               || other.GetComponent<Kid1Blackboard>()._CanTouched && !user1.GetComponent<Kid2Blackboard>()._CanTouched)
            {
                CanFoll = false;
            }
            else
            {
            CanFoll = user1.GetComponent<Kid2Blackboard>()._CanTouched;

            }
        }

        return CanFoll;

    }
} 

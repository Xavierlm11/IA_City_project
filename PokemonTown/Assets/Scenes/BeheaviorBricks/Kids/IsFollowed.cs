using UnityEngine;
 
using Pada1.BBCore;
using Pada1.BBCore.Framework;
using UnityEngine.AI;
[Condition("MyConditions/Is Followed?")]
[Help("Checks is the kid has being touched by the other.")]
public class IsFollowed : ConditionBase
{
    [InParam("user")]
    [SerializeField]
    private GameObject user2;

    [InParam("OtherKid")]
    [SerializeField]
    private GameObject OtherKid2;


    public override bool Check()
    {
        
        bool followed = false;
        if(user2.name == "Kid2")
        {
            Kid2Blackboard user = user2.GetComponent<Kid2Blackboard>();
            Kid1Blackboard other = OtherKid2.GetComponent<Kid1Blackboard>();
            if (!user._CanTouched && other._CanTouched)
            {
                followed = true;

            }
            
        }
        if (user2.name == "Kid1")
        {
            Kid1Blackboard user = user2.GetComponent<Kid1Blackboard>();
            Kid2Blackboard other = OtherKid2.GetComponent<Kid2Blackboard>();
            if (!user._CanTouched && other._CanTouched)
            {
                followed = true;
            }
            if (!user._CanTouched && !other._CanTouched)
            {
                other.SendMessage("CanTouch");
                followed = true;

            }
            if (user._CanTouched && other._CanTouched)
            {
                user.CantTouch();
                followed = true;

               
            }


        }
        return followed;

    }
} 

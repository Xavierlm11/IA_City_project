using UnityEngine;

using Pada1.BBCore;
using Pada1.BBCore.Framework;

[Condition("MyConditions/Is the treasure available?")]
public class IsTreasureAvailable : ConditionBase
{
    [InParam("user")]
    [SerializeField]
    private GameObject user;

    public override bool Check()
    {
        bool isTheTreasureFree = !user.GetComponent<Thief>().hasTreasure;

        return isTheTreasureFree;
    }
}
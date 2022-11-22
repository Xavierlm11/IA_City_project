using UnityEngine;

using Pada1.BBCore;
using Pada1.BBCore.Framework;

[Condition("MyConditions/Is Thief Near?")]
[Help("Checks whether Thief is near the Victim.")]
public class IsThiefNear : ConditionBase
{
    [InParam("thief")]
    [SerializeField]
    private GameObject thief;

    [InParam("victim")]
    [SerializeField]
    private GameObject victim;

    [InParam("distance")]
    [SerializeField]
    private float distance;

    public override bool Check()
    { 
        bool isNear = Vector3.Distance(thief.transform.position, victim.transform.position) < distance;

        return isNear;
    }
}
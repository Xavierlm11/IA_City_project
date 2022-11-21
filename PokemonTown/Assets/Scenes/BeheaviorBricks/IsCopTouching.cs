using UnityEngine;

using Pada1.BBCore;
using Pada1.BBCore.Framework;

[Condition("MyConditions/Is Cop Touching?")]
[Help("Checks whether Thief is near the Victim.")]
public class IsCopTouching : ConditionBase
{
    [InParam("cop")]
    [SerializeField]
    private GameObject cop;

    [InParam("thief")]
    [SerializeField]
    private GameObject thief;

    [InParam("distance")]
    [SerializeField]
    private float distance;

    public override bool Check()
    { 
        bool isNear = Vector3.Distance(thief.transform.position, cop.transform.position) < distance;
        //Debug.Log(isNear.ToString()+"..."+ Vector3.Distance(thief.transform.position, victim.transform.position).ToString());

        return isNear;
    }
}
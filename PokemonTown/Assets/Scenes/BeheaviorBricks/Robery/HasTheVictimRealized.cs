using UnityEngine;

using Pada1.BBCore;
using Pada1.BBCore.Framework;
using UnityEngine.AI;

[Condition("MyConditions/Has The Victim Realized?")]
public class HasTheVictimRealized : ConditionBase
{
    [InParam("victim")]
    [SerializeField]
    private GameObject victim;

    [InParam("cop")]
    [SerializeField]
    private GameObject cop;

    public override bool Check()
    {
        bool getHasRealized = victim.GetComponent<SalaryMan>().CheckRealize();


        return getHasRealized;
    }
}
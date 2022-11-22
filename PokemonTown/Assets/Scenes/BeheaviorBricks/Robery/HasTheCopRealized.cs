using UnityEngine;

using Pada1.BBCore;
using Pada1.BBCore.Framework;
using UnityEngine.AI;

[Condition("MyConditions/Has The Cop Realized?")]
public class HasTheCopRealized : ConditionBase
{

    [InParam("cop")]
    [SerializeField]
    private GameObject cop;

    [InParam("thief")]
    [SerializeField]
    private GameObject thief;

    public override bool Check()
    {
        bool hasRealized = false;

        if (cop.GetComponent<Policeman>().hasRealized == true)
        {
            if (thief.GetComponent<Thief>().hasTreasure == true)
            {
                hasRealized = true;
            }
        }

        return hasRealized;
    }
}
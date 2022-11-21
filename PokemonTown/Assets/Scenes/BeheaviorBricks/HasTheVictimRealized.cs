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
        bool hasRealized;

        int num = Random.Range(0, 2);

        if (num == 0)
        {
            hasRealized = true;
            victim.GetComponent<SalaryMan>().Realize();
            Debug.Log("Realized");
        }
        else
        {
            hasRealized = false;
            Debug.Log("Not Realized");
        }

        return hasRealized;
    }
}
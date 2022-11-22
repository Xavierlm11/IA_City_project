using UnityEngine;

using Pada1.BBCore;
using Pada1.BBCore.Framework;
using UnityEngine.AI;

[Condition("MyConditions/Is The Treasure Selected?")]
public class IsTheTreasureSelected : ConditionBase
{
    [InParam("victim")]
    [SerializeField]
    private GameObject victim;

    [InParam("user")]
    [SerializeField]
    private GameObject user;

    [InParam("treasure")]
    [SerializeField]
    private GameObject treasure;

    public override bool Check()
    {
        bool IsSelected = true;

        //if(victim!=null && treasure != null)
        //{
        //    IsSelected = true;
        //}

        if(user.GetComponent<Thief>().hasThrown == true)
        {
            user.GetComponent<Thief>().hasThrown = false;
            IsSelected = false;
        }

        return IsSelected;
    }
}
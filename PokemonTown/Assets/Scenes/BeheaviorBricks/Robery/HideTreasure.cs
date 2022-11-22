using UnityEngine;

using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using UnityEngine.AI;

[Action("Hide Treasure")]
public class HideTreasure : BasePrimitiveAction
{
    [InParam("user")]
    [SerializeField]
    private GameObject user;

    [InParam("victim")]
    [SerializeField]
    private GameObject victim;

    [InParam("cop")]
    [SerializeField]
    private GameObject cop;

    public override void OnStart()
    {
        user.transform.GetComponent<Thief>().HideTreasure();
        victim.transform.GetComponent<SalaryMan>().SpawnTreasure();
        user.transform.GetComponent<Thief>().hasThrown = true;
        cop.transform.GetComponent<Policeman>().hasRealized = false;
        victim.transform.GetComponent<SalaryMan>().hasChecked = false;
    }

    public override TaskStatus OnUpdate()
    {
        return TaskStatus.COMPLETED;
    }

}
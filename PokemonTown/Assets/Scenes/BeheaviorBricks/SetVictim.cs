using UnityEngine;

using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;

[Action("SetVictim")]
public class SetVictim : BasePrimitiveAction
{
    [InParam("user")]
    [SerializeField]
    private GameObject user;

    [OutParam("victim")]
    public GameObject victim;

    [OutParam("treasure")]
    public GameObject trasure;

    public override void OnStart()
    {
        victim = user.transform.GetComponent<Thief>().GetNearestVictim();
        trasure = victim.GetComponent<SalaryMan>().pokeball;
    }

    public override TaskStatus OnUpdate()
    {
        return TaskStatus.COMPLETED;
    }

}
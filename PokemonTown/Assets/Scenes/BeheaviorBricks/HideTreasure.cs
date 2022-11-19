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

    public override void OnStart()
    {
        user.transform.GetComponent<Thief>().HideTreasure();
    }

    public override TaskStatus OnUpdate()
    {
        return TaskStatus.COMPLETED;
    }

}
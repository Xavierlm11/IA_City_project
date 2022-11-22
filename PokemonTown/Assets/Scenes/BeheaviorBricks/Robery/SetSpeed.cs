using UnityEngine;

using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using UnityEngine.AI;

[Action("SetSpeed")]
public class SetSpeed : BasePrimitiveAction
{
    [InParam("user")]
    [SerializeField]
    private GameObject user;

    [InParam("speed")]
    [SerializeField]
    private float speed;

    public override void OnStart()
    {
        user.GetComponent<NavMeshAgent>().speed = speed;
    }

    public override TaskStatus OnUpdate()
    {
        return TaskStatus.COMPLETED;
    }

}
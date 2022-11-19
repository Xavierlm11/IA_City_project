using UnityEngine;

using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using UnityEngine.AI;

[Action("Escape")]
public class Escape : BasePrimitiveAction
{
    [InParam("user")]
    [SerializeField]
    private GameObject user;

    [InParam("target")]
    [SerializeField]
    private GameObject target;

    [InParam("escapeDistance")]
    [SerializeField]
    private float escapeDistance;

    [InParam("runSpeed")]
    [SerializeField]
    private float runSpeed;

    [OutParam("escapePosition")]
    public Vector3 escapePosition { get; set; }

    public override void OnStart()
    {
        escapePosition = user.transform.GetComponent<Thief>().NewPos(escapeDistance);
        target.transform.position = escapePosition;
        user.transform.GetComponent<NavMeshAgent>().speed = runSpeed;
    }

    public override TaskStatus OnUpdate()
    {
        return TaskStatus.COMPLETED;
    }

}
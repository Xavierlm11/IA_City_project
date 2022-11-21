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

    [InParam("victim")]
    [SerializeField]
    private GameObject victim;

    [InParam("runSpeed")]
    [SerializeField]
    private float runSpeed;

    [OutParam("escapePosition")]
    public Vector3 escapePosition { get; set; }

    public override void OnStart()
    {
        //Vector3 copDir = (cop.transform.position-user.transform.position);
        //escapePosition = user.transform.GetComponent<Thief>().NewPos(escapeDistance);
        //target.transform.position = escapePosition;
        user.transform.GetComponent<NavMeshAgent>().speed = runSpeed;
        user.transform.GetComponent<Thief>().Hide();
        escapePosition = user.transform.GetComponent<Thief>().escapePos;

        //victim.GetComponent<SalaryMan>().hasChecked = true;
    }

    public override TaskStatus OnUpdate()
    {
        return TaskStatus.COMPLETED;
    }

}
using UnityEngine;

using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using UnityEngine.AI;

[Action("Vector3/Get Random Position In Area")]
public class GetRandomPosInArea : BasePrimitiveAction
{
    [InParam("user")]
    [SerializeField]
    private GameObject user;

    [OutParam("randomPosition")]
    [Help("Position randomly taken from the area")]
    public Vector3 randomPositionNN { get; set; }

    public override void OnStart()
    {
        user.GetComponent<GoToTarget>().NewPos();
    }

    public override TaskStatus OnUpdate()
    {
       // Debug.DrawLine(user.transform.position, randomPosition, Color.yellow);
        return TaskStatus.COMPLETED;
    }

}
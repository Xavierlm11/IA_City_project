using UnityEngine;

using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;

[Action("SetTreasure")]
public class SetTreasure : BasePrimitiveAction
{
    [InParam("user")]
    [SerializeField]
    private GameObject user;

    [OutParam("treasure")]
    public GameObject treasure;

    public override void OnStart()
    {
        treasure = user.transform.GetComponent<Thief>().GetNearestVictim();
    }

    public override TaskStatus OnUpdate()
    {
        return TaskStatus.COMPLETED;
    }

}
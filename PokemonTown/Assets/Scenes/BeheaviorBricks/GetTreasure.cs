using UnityEngine;

using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;

[Action("Vector3/GetTreasure")]
public class GetTreasure : BasePrimitiveAction
{
    [InParam("user")]
    [SerializeField]
    private GameObject user;

    [InParam("treasure")]
    [SerializeField]
    private GameObject treasure;

    public override void OnStart()
    {
        treasure.transform.parent = user.transform;
        treasure.transform.localPosition = new Vector3(0,0.03f,0);
        user.transform.GetComponent<Thief>().hasTreasure = true;
        //Debug.Log("STEAL");
    }

    public override TaskStatus OnUpdate()
    {
        return TaskStatus.COMPLETED;
    }

}
using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework; // BasePrimitiveAction

[Action("MyActions/Wait")]
[Help("Waits.")]
public class Wait : BasePrimitiveAction
{
    [InParam("user")]
    [SerializeField]
    private GameObject user3;
    public override void OnStart()
    {
        if(user3.name=="Kid1")
        {
            user3.GetComponent<Kid1Blackboard>().Stop();
        }
        if (user3.name == "Kid2")
        {
            user3.GetComponent<Kid2Blackboard>().Stop();
        }
    }
    public override TaskStatus OnUpdate()
    {
        
        return TaskStatus.COMPLETED;
    }
}


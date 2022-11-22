using UnityEngine;

using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using UnityEngine.AI;

[Action("Vector3/GetRandomPositionAround")]
public class GetRandomPosAround : BasePrimitiveAction
{
    //[InParam("user")]
    //[SerializeField]
    //private GameObject user;

    [InParam("targetPosObj")]
    [SerializeField]
    private GameObject targetPosObj;

    [InParam("around target")]
    [SerializeField]
    private GameObject aroundTarget;

    [InParam("radius")]
    [SerializeField]
    private float radius;

    //[InParam("slow speed")]
    //[SerializeField] 
    //private float slowSpeed;

    [OutParam("randomPosition")]
    [Help("Position randomly taken from the area")]
    public Vector3 randomPosition { get; set; }

    public override void OnStart()
    {
        float targetPosY = aroundTarget.transform.position.y;
        
        randomPosition = new Vector3(aroundTarget.transform.position.x + Random.insideUnitSphere.x, targetPosY, aroundTarget.transform.position.z + Random.insideUnitSphere.z);
        // Debug.DrawLine(user.transform.position, randomPosition, Color.yellow);
        targetPosObj.transform.position = randomPosition;
       // user.GetComponent<NavMeshAgent>().speed = slowSpeed;
    }

    public override TaskStatus OnUpdate()
    {
       // Debug.DrawLine(user.transform.position, randomPosition, Color.yellow);
        return TaskStatus.COMPLETED;
    }

}
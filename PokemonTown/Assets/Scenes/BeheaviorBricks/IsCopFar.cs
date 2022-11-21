using UnityEngine;

using Pada1.BBCore;
using Pada1.BBCore.Framework;
using UnityEngine.AI;

[Condition("MyConditions/Is Cop Far?")]
[Help("Checks whether Cop is far from the Treasure.")]
public class IsCopFar : ConditionBase
{
    [InParam("treasure")]
    [SerializeField]
    private GameObject treasure;

    [InParam("cop")]
    [SerializeField]
    private GameObject cop;

    [InParam("thief")]
    [SerializeField]
    private GameObject thief;

    //[InParam("medium speed")]
    //[SerializeField]
    //private float mediumSpeed;

    //[InParam("fast speed")]
    //[SerializeField]
    //private float fastSpeed;

    [InParam("distance")]
    [SerializeField]
    private float distance;

    public override bool Check()
    {

        bool isFar = Vector3.Distance(cop.transform.position, treasure.transform.position) > distance;
        if (isFar == false)
        {
            Debug.DrawLine(cop.transform.position, treasure.transform.position, Color.green);
            //Debug.Log("NO NO NO");
            //thief.GetComponent<NavMeshAgent>().speed = mediumSpeed;
        }
        else
        {
            Debug.DrawLine(cop.transform.position, treasure.transform.position, Color.red);
            //Debug.Log("YES YES YES");
            //thief.GetComponent<NavMeshAgent>().speed = fastSpeed;
        }

        
        return isFar;
    }
}
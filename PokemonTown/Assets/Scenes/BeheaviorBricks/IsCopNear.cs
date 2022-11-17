using UnityEngine;

using Pada1.BBCore;
using Pada1.BBCore.Framework;

[Condition("MyConditions/Is Cop Near?")]
[Help("Checks whether Cop is near the Treasure.")]
public class IsCopNear : ConditionBase
{
    [InParam("treasure")]
    [SerializeField]
    private GameObject treasure;

    [InParam("cop")]
    [SerializeField]
    private GameObject cop;

    [InParam("distance")]
    [SerializeField]
    private float distance;

    public override bool Check()
    {
        //Debug.Log("AAAAAAAAA");
        if(Vector3.Distance(cop.transform.position, treasure.transform.position) < distance == true)
        {
            Debug.DrawLine(cop.transform.position, treasure.transform.position, Color.green);
            Debug.Log("YES YES YES");
        }
        else
        {
            Debug.DrawLine(cop.transform.position, treasure.transform.position, Color.red);
            Debug.Log("NO NO NO");
        }

        
        return Vector3.Distance(cop.transform.position, treasure.transform.position) < distance;
    }
}
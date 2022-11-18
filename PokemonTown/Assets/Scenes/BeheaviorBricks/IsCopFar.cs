using UnityEngine;

using Pada1.BBCore;
using Pada1.BBCore.Framework;

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

    [InParam("distance")]
    [SerializeField]
    private float distance;

    public override bool Check()
    {
        //Debug.Log("AAAAAAAAA");

        bool isFar = Vector3.Distance(cop.transform.position, treasure.transform.position) > distance;
        if (isFar == false)
        {
            Debug.DrawLine(cop.transform.position, treasure.transform.position, Color.green);
            Debug.Log("NO NO NO");
        }
        else
        {
            Debug.DrawLine(cop.transform.position, treasure.transform.position, Color.red);
            Debug.Log("YES YES YES");
        }

        
        return isFar;
    }
}
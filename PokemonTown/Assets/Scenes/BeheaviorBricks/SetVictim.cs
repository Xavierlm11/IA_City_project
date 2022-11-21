using UnityEngine;

using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;

[Action("SetVictim")]
public class SetVictim : BasePrimitiveAction
{
    [InParam("user")]
    [SerializeField]
    private GameObject user;

    [OutParam("victim")]
    [SerializeField]
    public GameObject victim;

    [OutParam("treasure")]
    [SerializeField]
    public GameObject treasure;

    public override void OnStart()
    {
        victim = user.transform.GetComponent<Thief>().GetNearestVictim();
        Debug.Log("Victim: "+victim.name);
        treasure = victim.GetComponent<SalaryMan>().pokeball;
        Debug.Log("Treasure: " + treasure.name);
        //Debug.Log("AAA");
    }

    public override TaskStatus OnUpdate()
    {
        return TaskStatus.COMPLETED;
    }

}
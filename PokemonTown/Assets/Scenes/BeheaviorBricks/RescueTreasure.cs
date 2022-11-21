using UnityEngine;

using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;

[Action("RescueTreasure")]
public class RescueTreasure : BasePrimitiveAction
{
    [InParam("cop")]
    [SerializeField]
    private GameObject cop;

    [InParam("thief")]
    [SerializeField]
    private GameObject thief;

    public override void OnStart()
    {
        if(thief.GetComponent<Thief>().pokeball != null)
        {
            cop.GetComponent<Policeman>().hasRealized = false;
            thief.GetComponent<Thief>().DestroyTreasure();
            thief.GetComponent<Thief>().currentVictim.GetComponent<SalaryMan>().SpawnTreasure();
            thief.GetComponent<Thief>().currentVictim.transform.GetComponent<SalaryMan>().hasChecked = false;
            thief.GetComponent<Thief>().currentVictim = null;
            
        }
    }

    public override TaskStatus OnUpdate()
    {
        return TaskStatus.COMPLETED;
    }

}
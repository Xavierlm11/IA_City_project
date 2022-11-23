using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework; // BasePrimitiveAction

[Action("MyActions/KidRun")]
[Help("Get the GameObj to Follow another GameObj.")]
public class HideBB : BasePrimitiveAction
{
    [InParam("game object")]
    [Help("Game object to add the component, if no assigned the component is added to the game object of this behavior")]
    public GameObject targetGameobject;

    [OutParam("hide")]
    [Help("Vector3 for higing.")]
    public Vector3 hide;

    //public override TaskStatus OnUpdate()
    //{
    //    //Moves moves = targetGameobject.GetComponent<Moves>(); 
    //    //hide = moves.HideValue();
    //    //return TaskStatus.COMPLETED;
    //}
}


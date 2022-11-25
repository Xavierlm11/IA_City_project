using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OldManWalk : MonoBehaviour
{
   
    [SerializeField] private float radius;
    [SerializeField] private float offset;
    [SerializeField] public NavMeshAgent agent;
   

    private Vector3 localTarget;
    private Vector3 worldTarget;
   
    public void SetRandPostion()
    {
        if (agent.transform.position == agent.destination)
        {
            localTarget = UnityEngine.Random.insideUnitCircle * radius;
            localTarget += new Vector3(0, 0, offset);
            worldTarget = transform.TransformPoint(localTarget);
            worldTarget.y = 0f;
        }
        agent.destination = worldTarget;
    }

    public void Seek(GameObject target)
    {
        agent.destination = target.transform.position;

    }
    // Start is called before the first frame update
    void Start()
    {
        agent.transform.position = agent.destination;
        //SetRandPostion();
    }

    // Update is called once per frame
  //  void Update()
    //{
     
       // if (agent.transform.position == agent.destination)
       // {
          //  SetRandPostion();
      //  }
        //Gizmos.color = Color.red;
        //Gizmos.DrawSphere(agent.destination,radius);
       // agent.destination = worldTarget;
        
   // }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//a
public class wander : MonoBehaviour
{
    // Start is called before the first frame update
    //Vector3 a;
    void Start()
    {
        //a = agent.transform.position;
        //agent.destination = agent.transform.position;
    }

    [SerializeField] private float radius;
    [SerializeField] private float offset;
    [SerializeField] private NavMeshAgent agent;
    //private float freq = 0f;


    [SerializeField] private float Velrot;
    private Quaternion rot;
    private float ang;
    private float freq = 0f;
    // Update is called once per frame
    void Update()
    {
        // parameters: float radius, offset;
        
        freq += Time.deltaTime;
        if (freq > 0.5)
        {
            freq -= 0.6f;
            Vector3 localTarget = UnityEngine.Random.insideUnitCircle * radius; 
            localTarget += new Vector3(0, 0, offset);
            Vector3 worldTarget = transform.TransformPoint(localTarget);
            worldTarget.y = 0f;

            ang = Mathf.Rad2Deg * Mathf.Atan2(worldTarget.x, worldTarget.z);
            agent.destination = worldTarget;
        }
        
        rot = Quaternion.AngleAxis(ang, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * Velrot);
       
       // freq += Time.deltaTime;
        //if (a == agent.transform.position)
        //{
            //freq -= 3;
        //}
       
        //NavMesh.SamplePosition();

    }
}

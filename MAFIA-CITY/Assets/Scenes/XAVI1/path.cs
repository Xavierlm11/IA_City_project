using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class path : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public NavMeshAgent agent;
    public GameObject target;


    [SerializeField] private float Velrot;
    private Quaternion rot;
    private float ang;
    //[SerializeField] private float radius;
    //[SerializeField] private float offset;

    void Seek1()
    {
        agent.destination = target.transform.position;

        ang = Mathf.Rad2Deg * Mathf.Atan2(target.transform.position.x, target.transform.position.z);
       
        rot = Quaternion.AngleAxis(ang, Vector3.up);
    }
    // Update is called once per frame
    void Update()
    {
        //// parameters: float radius, offset;
        //Vector3 localTarget = UnityEngine.Random.insideUnitCircle * radius;
        //localTarget += new Vector3(0, 0, offset);
        //Vector3 worldTarget = transform.TransformPoint(localTarget);
        //worldTarget.y = 0f;

        Seek1();

    }
}

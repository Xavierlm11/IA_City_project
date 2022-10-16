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

    void Seek1()
    {
        agent.destination = target.transform.position;

    }
    // Update is called once per frame
    void Update()
    {
        Seek1();

    }
}

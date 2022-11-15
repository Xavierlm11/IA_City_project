using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DuckPath : MonoBehaviour
{
    
    public NavMeshAgent agent;
    public GameObject target;

    void Seek()
    {
        agent.destination = target.transform.position;

    }
    void Update()
    {
        Seek();
    }
}

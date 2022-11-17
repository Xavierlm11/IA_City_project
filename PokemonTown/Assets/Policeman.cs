using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Policeman : MonoBehaviour
{
    public NavMeshAgent navMesh;
    public Transform target;

    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        navMesh.destination = target.position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Policeman : MonoBehaviour
{
    public NavMeshAgent navMesh;

    public bool hasRealized;

    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
    }

    public void Realize()
    {
        hasRealized = true;
    }

}

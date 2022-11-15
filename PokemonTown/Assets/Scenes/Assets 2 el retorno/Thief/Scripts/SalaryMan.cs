using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SalaryMan : MonoBehaviour
{
    [SerializeField] private float freq;
    private float activeTime;
    public NavMeshAgent navMesh;
    [SerializeField]
    private Transform target;

    [SerializeField] private MeshRenderer ground;
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        NewPos();
    }

    void Update()
    {
        activeTime += Time.deltaTime;
        if (activeTime > freq)
        {
            activeTime -= freq;

            NewPos();
        }
    }


    private void NewPos()
    {
        float x = Random.Range(ground.bounds.min.x, ground.bounds.min.x + ground.bounds.size.x);
        float z = Random.Range(ground.bounds.min.z, ground.bounds.min.z + ground.bounds.size.z);


        target.position = new Vector3(x, transform.position.y, z);
        navMesh.destination = target.position;
    }

}

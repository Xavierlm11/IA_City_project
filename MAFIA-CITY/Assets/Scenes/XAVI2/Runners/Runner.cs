using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Runner : MonoBehaviour
{
    public NavMeshAgent agent;
    public List<GameObject> targets;
    public int activetarget;
    public int speed;

    void Start()
    {
        agent.speed = speed;
        activetarget = 0;
        Seek();
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PathPoint")
        {
            print("Contact");
            NextPoint();
        }
    }

    void Seek()
    {
        agent.destination = targets[activetarget].transform.position;
    }

    private void NextPoint()
    {
        if (activetarget + 1 == targets.Count)
        {
            activetarget = 0;
        }
        else
        {
            activetarget++;
        }
        Seek();
    }
}

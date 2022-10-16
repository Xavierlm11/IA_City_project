using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Runner : MonoBehaviour
{
    public NavMeshAgent agent;
    public List<GameObject> targets;
    public int activetarget;
    public float speed;
    public FlockingManager flockManager;
    public RunnerManager runnerManager;
    public int nearBees;

    [SerializeField] private Vector3 beeVec;

    void Start()
    {
        agent.speed = speed;
        activetarget = 0;
        Seek();
    }

    void Update()
    {
         RunAway();
    }

    private void RunAway()
    {
        nearBees = 0;

        foreach (GameObject bee in flockManager.beesList)
        {
            float distance = Vector3.Distance(bee.transform.position, transform.position);
            if(distance <= runnerManager.beeDistance)
            {
                beeVec += bee.transform.position;
                nearBees++;
            }
        }

        if(nearBees > 0)
        {
            beeVec = (beeVec / nearBees - transform.position).normalized;
        }

        //transform.Translate(transform.position + beeVec * agent.speed * runnerManager.runAwayScale);
        transform.Translate(beeVec * agent.speed * runnerManager.runAwayScale);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PathPoint")
        {
            int index = targets.FindIndex(x => x.GetComponent<Collider>() == other);
            if(index != -1)
            {
                activetarget = index;
                NextPoint();
            }
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

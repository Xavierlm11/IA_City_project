using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockingManager : MonoBehaviour
{
    public List<GameObject> beesList;
    public GameObject bee;
    public int beesNum;
    public float minRange;
    public float maxRange;
    public float neighbourDistance;
    public float runnerDistance;
    public float originDistance;

    public float speed;
    public float minSpeed;
    public float maxSpeed;

    public float rotationSpeed;

    public float cohesionScale;
    public float separationScale;
    public float alignScale;


    public float seekScale;
    public float furtherScale;

    private FlockMovement activeFlockMovement;

    public float frequency;
    public Transform beeFolder;

    [SerializeField] private RunnerManager runnerManager;

    [SerializeField] private GameObject beeSpawn;

    void Start()
    {
        for(int i = 0; i < beesNum; i++)
        {
            Vector3 randomPos = new Vector3(Random.Range(minRange, maxRange), Random.Range(minRange, maxRange), Random.Range(minRange, maxRange));
            GameObject bid = Instantiate(bee, beeFolder);
            bid.transform.position = beeFolder.position + randomPos;
            activeFlockMovement = bid.GetComponent<FlockMovement>();
            activeFlockMovement.flockManager = this;
            activeFlockMovement.runnerManager = runnerManager;
            activeFlockMovement.beeSpawn = beeSpawn;
           // activeFlockMovement.cohesionScale = cohesionScale;
           // activeFlockMovement.separationScale = separationScale;
           // activeFlockMovement.alignScale = alignScale;
            //activeFlockMovement.frequency = frequency;
            beesList.Add(bid);
        }
    }
}

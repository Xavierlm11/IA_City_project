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

    public float speed;
    public float minSpeed;
    public float maxSpeed;

    public float rotationSpeed;

    void Start()
    {
        for(int i = 0; i < beesNum; i++)
        {
            Vector3 randomPos = new Vector3(Random.Range(minRange, maxRange), Random.Range(minRange, maxRange), Random.Range(minRange, maxRange));
            GameObject bid = Instantiate(bee);
            bid.transform.position = transform.position + randomPos;
            bid.GetComponent<FlockMovement>().flockManager = this;
            beesList.Add(bid);
        }
    }
}

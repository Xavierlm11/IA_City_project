using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockingManager : MonoBehaviour
{
    public List<GameObject> bidoofList;
    public GameObject bidoof;
    public int bidoofsNum;
    public float minRange;
    public float maxRange;
    public float neighbourDistance;

    public float minSpeed;
    public float maxSpeed;

    void Start()
    {
       
        for(int i = 0; i < bidoofsNum; i++)
        {
            Vector3 randomPos = new Vector3(Random.Range(minRange, maxRange), Random.Range(minRange, maxRange), Random.Range(minRange, maxRange));
            GameObject bid = Instantiate(bidoof);
            bid.transform.position = transform.position + randomPos;
            bid.GetComponent<FlockCohesion>().flock = this;
            bid.GetComponent<FlockAlign>().flock = this;
            bid.GetComponent<FlockSeparation>().flock = this;
            bidoofList.Add(bid);
        }
    }

    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockCohesion : MonoBehaviour
{
    public Vector3 cohesion = Vector3.zero;
    public int nearBids = 0;
    public FlockingManager flock;
    public float speed;

    void Start()
    {
        
    }

    void Update()
    {
        foreach (GameObject bid in flock.bidoofList)
        {
            if(bid != gameObject)
            {
                float distance = Vector3.Distance(bid.transform.position, transform.position);
                if(distance <= flock.neighbourDistance)
                {
                    cohesion += bid.transform.position;
                    nearBids++;
                }
            }
        }

        if(nearBids > 0)
        {
            cohesion = (cohesion / nearBids - transform.position).normalized * speed;
        }
    }
}

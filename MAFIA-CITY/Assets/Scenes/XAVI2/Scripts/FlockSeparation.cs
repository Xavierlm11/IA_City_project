using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockSeparation : MonoBehaviour
{
    public Vector3 separation = Vector3.zero;
    public FlockingManager flock;
    void Start()
    {
        
    }

    void Update()
    {
        //foreach (GameObject bid in flock.bidoofList)
        //{
        //    if (bid != gameObject)
        //    {
        //        float distance = Vector3.Distance(bid.transform.position, transform.position);
        //        if (distance <= flock.neighbourDistance)
        //        {
        //            separation -= (transform.position - bid.transform.position) / (distance * distance);
        //        }
        //    }
        //}
    }
}

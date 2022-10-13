using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockAlign : MonoBehaviour
{
    public Vector3 align;
    public FlockingManager flock;
    int bidNum = 0;
    public float speed;

    void Update()
    {
        //align = Vector3.zero;
        //bidNum = 0;

        //foreach (GameObject bid in flock.bidoofList)
        //{
        //    if (bid != gameObject)
        //    {
        //        float distance = Vector3.Distance(bid.transform.position, transform.position);
        //        if (distance <= flock.neighbourDistance)
        //        {
        //            align += bid.GetComponent<FlockingMovement>().direction;
        //            bidNum++;
        //        }
        //    }
        //}
        //if (bidNum > 0)
        //{
        //    align /= bidNum;
        //    speed = Mathf.Clamp(align.magnitude, flock.minSpeed, flock.maxSpeed);
        //}
    }
}

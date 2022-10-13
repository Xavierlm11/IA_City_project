using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockingMovement : MonoBehaviour
{
    public float speed;
    public Vector3 direction;


    void Start()
    {
        Vector3 direction = (gameObject.GetComponent<FlockCohesion>().cohesion + gameObject.GetComponent<FlockAlign>().align + gameObject.GetComponent<FlockSeparation>().separation).normalized * speed;
    }

    void Update()
    {
        
    }
}

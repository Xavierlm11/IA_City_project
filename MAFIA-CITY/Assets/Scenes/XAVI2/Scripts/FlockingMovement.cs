using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockingMovement : MonoBehaviour
{
    public Vector3 direction;
    public FlockingManager flock;
    public Vector3 co;
    public Vector3 al;
    public Vector3 se;
    public float freq = 0f;

    void Update()
    {
        freq += Time.deltaTime;
        if (freq > 0.5)
        {
            freq -= 0.5f;

            SetDir();
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), flock.rotationSpeed * Time.deltaTime);
        transform.Translate(0.0f, 0.0f, Time.deltaTime * flock.speed);
    }

    private void SetDir()
    {
        co = gameObject.GetComponent<FlockCohesion>().cohesion;
        al = gameObject.GetComponent<FlockAlign>().align;
        se = gameObject.GetComponent<FlockSeparation>().separation;
        direction = (co + al + se).normalized * flock.speed;
    }
}

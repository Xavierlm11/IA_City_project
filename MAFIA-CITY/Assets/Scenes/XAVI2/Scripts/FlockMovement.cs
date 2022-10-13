using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockMovement : MonoBehaviour
{

    public Vector3 cohesionVec;
    public Vector3 separationVec;
    public Vector3 alignVec;

    public int nearBees;

    public float speed;
    public FlockingManager flockManager;


    public Vector3 direction;

    public float freq;

    private void Update()
    {
        freq += Time.deltaTime;
        if (freq > 0.25)
        {
            freq -= 0.25f;

            SetDir();
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), flockManager.rotationSpeed * Time.deltaTime);
        transform.Translate(0.0f, 0.0f, Time.deltaTime * flockManager.speed);
    }

    private void SetDir()
    {
        nearBees = 0;
        
        foreach (GameObject bid in flockManager.beesList)
        {
            if (bid != gameObject)
            {
                float distance = Vector3.Distance(bid.transform.position, transform.position);
                if (distance <= flockManager.neighbourDistance)
                {
                    cohesionVec += bid.transform.position;

                    separationVec -= (transform.position - bid.transform.position) / (distance * distance) * 0.5f;
                    alignVec += direction;

                    nearBees++;
                }
            }

        }

        if (nearBees > 0)
        {
            alignVec /= nearBees;
            speed = Mathf.Clamp(alignVec.magnitude, flockManager.minSpeed, flockManager.maxSpeed);

            cohesionVec = (cohesionVec / nearBees - transform.position).normalized * flockManager.speed;
        }

        direction = (cohesionVec + alignVec + separationVec).normalized * flockManager.speed;
    }

}

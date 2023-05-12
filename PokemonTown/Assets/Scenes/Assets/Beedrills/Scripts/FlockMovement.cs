using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockMovement : MonoBehaviour
{

    [SerializeField] private Vector3 cohesionVec;
    [SerializeField] private Vector3 separationVec;
    [SerializeField] private Vector3 alignVec;

    [SerializeField] private Vector3 seekVec;
    [SerializeField] private Vector3 furtherVec;


    [SerializeField] private int nearBees;
    [SerializeField] private int nearRunners;

    [SerializeField] private float speed;
    public FlockingManager flockManager;


    [SerializeField] private Vector3 direction;

    [SerializeField] private float freq;

    public GameObject beeSpawn;


    private void Update()
    {
        freq += Time.deltaTime;
        if (freq > flockManager.frequency)
        {
            freq -= flockManager.frequency;

            SetDir();
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), flockManager.rotationSpeed * Time.deltaTime);
        transform.Translate(0.0f, 0.0f, Time.deltaTime * speed);
    }

    private void SetDir()
    {
        nearBees = 0;
        nearRunners = 0;
        alignVec = Vector3.zero;
        cohesionVec = Vector3.zero;
        separationVec = Vector3.zero;

        seekVec = Vector3.zero;
        furtherVec = Vector3.zero;

        foreach (GameObject bee in flockManager.beesList)
        {
            if (bee != gameObject)
            {
                float distance = Vector3.Distance(bee.transform.position, transform.position);
                if (distance <= flockManager.neighbourDistance)
                {
                    cohesionVec += bee.transform.position;

                    separationVec -= (transform.position - bee.transform.position) / (distance * distance);
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

        if(nearRunners > 0)
        {
            seekVec = (seekVec / nearRunners - transform.position).normalized * flockManager.speed;
        }

        float distanceToOrigin = Vector3.Distance(transform.position, beeSpawn.transform.position);
        furtherVec += ( beeSpawn.transform.position - transform.position) * distanceToOrigin;
        
        direction = (cohesionVec * flockManager.cohesionScale + alignVec * flockManager.alignScale + separationVec * flockManager.separationScale + seekVec * flockManager.seekScale + furtherVec * flockManager.furtherScale).normalized * flockManager.speed;

        
    }
}

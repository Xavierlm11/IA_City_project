using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockMovement : MonoBehaviour
{

    [SerializeField] private Vector3 cohesionVec;
    [SerializeField] private Vector3 separationVec;
    [SerializeField] private Vector3 alignVec;

    [SerializeField] private int nearBees;

    [SerializeField] private float speed;
    public FlockingManager flockManager;


    [SerializeField] private Vector3 direction;

    [SerializeField] private float freq;

    public float cohesionScale;
    public float separationScale;
    public float alignScale;


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
        alignVec = Vector3.zero;
        cohesionVec = Vector3.zero;
        separationVec = Vector3.zero;

        foreach (GameObject bid in flockManager.beesList)
        {
            if (bid != gameObject)
            {
                float distance = Vector3.Distance(bid.transform.position, transform.position);
                if (distance <= flockManager.neighbourDistance)
                {
                    cohesionVec += bid.transform.position;

                    separationVec -= (transform.position - bid.transform.position) / (distance * distance);
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

        direction = (cohesionVec* flockManager.cohesionScale + alignVec* flockManager.alignScale + separationVec* flockManager.separationScale).normalized * flockManager.speed;
    }

}

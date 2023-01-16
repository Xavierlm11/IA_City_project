using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using UnityEngine;
using System.Collections.Generic;

public class RollerAgent : Agent
{
    [SerializeField] private Rigidbody rBody;
    [SerializeField] private SphereCollider col;
    [SerializeField] private Transform Target;
    [SerializeField] private float forceMultiplier = 10;
    [SerializeField] private float targetCol;
    [SerializeField] private float time;
    [SerializeField] private float obsDistance;
    public List<Collider> obsList;

    private bool somethingBetween;
    [SerializeField] private Vector3 closestPos;

    //[SerializeField] private float time;

    public override void Initialize()
    {
        rBody = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
    }
        
   public override void OnEpisodeBegin()
   {
       // print("Start");
        // If the Agent fell, zero its momentum
        if (transform.localPosition.y < 0)
        {
            rBody.angularVelocity = Vector3.zero;
            rBody.velocity = Vector3.zero;
            transform.localPosition = new Vector3(0, 0.5f, 4);
        }


        // Move the target to a new random spot
        Target.localPosition = new Vector3(Random.Range(-14f, 14f), 0.5f, Random.Range(-14f, 14f));

        time = 0;
    }
    public override void CollectObservations(VectorSensor sensor)
    {
       // print("B");
        // Target and Agent positions, size = 3x2
        sensor.AddObservation(Target.localPosition);
        sensor.AddObservation(transform.localPosition);
        // Agent velocity, size = 2
        sensor.AddObservation(rBody.velocity.x);
        sensor.AddObservation(rBody.velocity.z);

        sensor.AddObservation(somethingBetween);


       
        sensor.AddObservation(closestPos);


    }
    // sensor.AddObservation(item);
    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
       
       // print("A");
        // Actions, size = 2
        Vector3 controlSignal = Vector3.zero;
        controlSignal.x = actionBuffers.ContinuousActions[0];
        controlSignal.z = actionBuffers.ContinuousActions[1];
        rBody.AddForce(controlSignal * forceMultiplier);

        // Rewards
        float distanceToTarget = Vector3.Distance(transform.localPosition, Target.localPosition);

        // Reached target
        if (distanceToTarget < targetCol)
        {
            SetReward(8.0f);
            EndEpisode();
        }

        // Fell off platform
        else if (transform.localPosition.y < 0)
        {
            SetReward(-1.0f);
            EndEpisode();
        }

        float colDist = 0;
        Collider closeCol = null;

        foreach (Collider obs in obsList)
        {
            if (obs == obsList[0])
            {
                colDist = Vector3.Distance(transform.position, obs.ClosestPoint(transform.position));
                closeCol = obs;
            }
            else
            {
                float newDist = Vector3.Distance(transform.position, obs.ClosestPoint(transform.position));
                if (newDist <= colDist)
                {
                    print("Change");
                    colDist = newDist;
                    closeCol = obs;
                }
            }
        }
        //for(int i = 0; i < obsList.Count; ++i)
        //{
        //    print("Item " + i.ToString() + ": "+ Vector3.Distance(transform.position, obsList[i].ClosestPoint(transform.position)).ToString());
        //}
        //print("Final: " + Vector3.Distance(transform.position, closeCol.ClosestPoint(transform.position)).ToString());
        closestPos = transform.InverseTransformPoint(closeCol.ClosestPoint(transform.position));

    }
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = -Input.GetAxis("Horizontal");
        continuousActionsOut[1] = -Input.GetAxis("Vertical");
    }

    //void OnTriggerEnter(Collider col)
    //{
    //    // Reached target
    //    if (col.transform.CompareTag("goal"))
    //    {
    //        SetReward(1.0f);
    //        EndEpisode();
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        //if(collision.gameObject.tag == "wall")
        //{

        //}

        print("Collision");
        SetReward(-0.5f);
        EndEpisode();
        rBody.angularVelocity = Vector3.zero;
        rBody.velocity = Vector3.zero;
        transform.localPosition = new Vector3(0, 0.5f, 4);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, Target.position);
        Gizmos.DrawWireSphere(Target.position, targetCol);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, closestPos);
        
    }

    public void Update()
    {

        


        time += Time.deltaTime;
        if (time >= 10f)
        {
            time = 0;
            SetReward(-0.1f);
            EndEpisode();
            print("TIME OUT");

        }

        //if (GetCumulativeReward() <= -1.0f)
        //{
        //    print("TIME OUT");
        //    SetReward(-1.0f);
        //    EndEpisode();
        //    // transform.localPosition = new Vector3(0, 0.5f, 0);
        //}

        RaycastHit hit;
        if (Physics.Linecast(transform.position, Target.transform.position, out hit))
        {
            if (hit.transform != transform && hit.transform != Target.transform)
            {
                //there is something in the way
                print("BETWEEN");
                somethingBetween = true;
            }
            else
            {
                somethingBetween = false;
                print("FREE");
            }

        }
        else
        {
            somethingBetween = false;
            print("FREE");
        }
    }
}
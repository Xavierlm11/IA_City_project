using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class accmov : MonoBehaviour
{
     // Start is called before the first frame update
    void Start()
    {
        
    }

    [SerializeField]private GameObject target;
    private Vector3 direction;
    private Vector3 mov;
    private float ang;
    private int vel = 2;
    private Quaternion rot;
    private float freq = 0f;
    [SerializeField]private float Velrot;
    [SerializeField] private float stopDistance;
    private float turnSpeed;
    private float turnAcceleration = 2;
    private float maxTurnSpeed = 2;
    private float movSpeed;
    [SerializeField] private float acc = 2 ;
    [SerializeField] private float maxSpeed;

    // Update is called once per frame

    void Seek()
    {
        direction = target.transform.position - transform.position;
        mov = direction.normalized * acc ;
        ang= Mathf.Rad2Deg * Mathf.Atan2(mov.x, mov.z);
        rot = Quaternion.AngleAxis(ang, Vector3.up);
        
    }
    void Update()
    {
         if (Vector3.Distance(target.transform.position, transform.position) < stopDistance) return;
        //seek
        transform.rotation = Quaternion.Slerp(transform.rotation, rot,Time.deltaTime * Velrot);
        transform.position += transform.forward.normalized * vel * Time.deltaTime;
       
        freq += Time.deltaTime;
        if (freq > 0.3)
        {
            freq -= 0.3f;
             Seek();
        }

        turnSpeed += turnAcceleration * Time.deltaTime;
        turnSpeed = Mathf.Min(turnSpeed, maxTurnSpeed);
        
        movSpeed += acc * Time.deltaTime;
        movSpeed = Mathf.Min(movSpeed, maxSpeed);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * turnSpeed);
                                         
        transform.position += transform.forward.normalized * movSpeed *Time.deltaTime; 
                          
        // Update commands

    }
}

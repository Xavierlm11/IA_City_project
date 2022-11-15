using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMovement : MonoBehaviour
{

    [SerializeField]private GameObject target;
    private Vector3 direction;
    private Vector3 mov;
    private float ang;
    [SerializeField] private float vel = 2;
    private Quaternion rot;
    private float freq = 0f;
    [SerializeField]private float Velrot;


   void Seek()
    {
        direction = target.transform.position - transform.position;
        mov = direction.normalized * vel ;
        ang= Mathf.Rad2Deg * Mathf.Atan2(mov.x, mov.z);
        rot = Quaternion.AngleAxis(ang, Vector3.up);
        
    }
    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, rot,Time.deltaTime * Velrot);
        transform.position += transform.forward.normalized * vel * Time.deltaTime;
       
        freq += Time.deltaTime;
        if (freq > 0.3)
        {
            freq -= 0.3f;
             Seek();
        }

    }
}

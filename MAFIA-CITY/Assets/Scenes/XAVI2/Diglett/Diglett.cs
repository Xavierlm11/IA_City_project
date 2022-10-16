using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Diglett : MonoBehaviour
{
    [SerializeField] private float freqUp;
    [SerializeField] private float freqDown;
    private float activeTime;

    [SerializeField] private MeshRenderer ground;

    private bool hasToAppear;
    private bool hasToDisappear;

    [SerializeField] private AnimationClip appearAnim;
    [SerializeField] private AnimationClip disappearAnim;
    [SerializeField] private Animator anim;

    private bool isUp;

    [SerializeField] private Transform seeker;
    [SerializeField] private float rotationSpeed;

    void Start()
    {
        
    }

    void Update()
    {
       // Vector3 direction = (seeker.position - transform.position);
       // direction.y = 0;
        
       // Quaternion rotation = Quaternion.LookRotation(direction);
       // // Quaternion finalRotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
       // transform.rotation = rotation;//Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
       //// transform.Rotate();
       // //Debug.DrawLine(transform.position, seeker.position, Color.magenta, 0);
       //// Debug.DrawLine(ground.bounds.min, ground.bounds.min + ground.bounds.size, Color.magenta, 0);
        if (isUp == true)
        {
            activeTime += Time.deltaTime;
            if (activeTime > freqUp)
            {
                activeTime -= freqUp;

                Disappear();
            }


            if (hasToDisappear == true)
            {
                CheckDisappear();
            }
        }
        else
        {
            activeTime += Time.deltaTime;
            if (activeTime > freqDown)
            {
                activeTime -= freqDown;

                Appear();
            }

            if (hasToAppear == true)
            {
                CheckAppear();
            }
        }

    }

    private void Disappear()
    {
        
        hasToDisappear = true;
        
    }

    private void Appear()
    {

        hasToAppear = true;

        seeker.GetComponent<NavMeshAgent>().destination = transform.position;
                                     

    }

    private void CheckAppear() 
    {       
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Appear") == true)
        {
            if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            {
                hasToAppear = false;
                isUp = true;
            }
        }
        else
        {
            anim.Play("Appear");
        }

        Vector3 direction = (seeker.position - transform.position);
        direction.y = 0;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;

    }

    private void CheckDisappear()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Disappear") == true)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            {
                hasToDisappear = false;
                isUp = false;
                NewPos();
            }
        }
        else
        {
            anim.Play("Disappear");
        }
    }

    private void NewPos()
    {
        float x = Random.Range(ground.bounds.min.x, ground.bounds.min.x + ground.bounds.size.x);
        float z = Random.Range(ground.bounds.min.z, ground.bounds.min.z + ground.bounds.size.z);

        transform.position = new Vector3(x, transform.position.y, z);
    }

}

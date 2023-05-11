using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private Rigidbody rgbd;
    [SerializeField] private float idleSpeed;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
        {
            if (rgbd.velocity.magnitude <= idleSpeed)
            { 
                animator.SetBool("isRunning", false);
            }
        } 
        else 
        { 
            animator.SetBool("isRunning", true); 
        }
    }
}

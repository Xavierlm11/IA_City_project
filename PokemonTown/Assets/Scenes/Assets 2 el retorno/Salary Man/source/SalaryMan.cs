using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToTarget : MonoBehaviour
{
    public NavMeshAgent navMesh;
    public Transform target;

    [SerializeField] private List<MeshRenderer> nonWalkable;
    [SerializeField] private MeshRenderer ground;

    public float targetRadius;

    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
    }

    public void NewPos()
    {
        float x = Random.Range(ground.bounds.min.x, ground.bounds.min.x + ground.bounds.size.x);
        float z = Random.Range(ground.bounds.min.z, ground.bounds.min.z + ground.bounds.size.z);

        bool isValid = false;

        while (isValid == false)
        {
            x = Random.Range(ground.bounds.min.x, ground.bounds.min.x + ground.bounds.size.x);
            z = Random.Range(ground.bounds.min.z, ground.bounds.min.z + ground.bounds.size.z);

            bool isValidThisTime = true;
            foreach (MeshRenderer plane in nonWalkable)
            {
                if (((x > plane.bounds.min.x) && (x < plane.bounds.min.x + plane.bounds.size.x)) && ((z > plane.bounds.min.z) && (z < plane.bounds.min.z + plane.bounds.size.z)))
                {
                    print("Inside");
                    isValidThisTime = false;
                }
            }

            if(isValidThisTime == true)
            {
                isValid = true;
            }

           
        }
        

        target.position = new Vector3(x, transform.position.y, z);
        navMesh.destination = target.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(target.position, targetRadius);
    }

}

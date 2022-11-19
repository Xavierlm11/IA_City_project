using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Thief : MonoBehaviour
{
    public bool hasTreasure;

    public NavMeshAgent navMesh;
    public Transform target;

    [SerializeField] private List<MeshRenderer> nonWalkable;
    [SerializeField] private MeshRenderer ground;

    public GameObject pokeballParent;
    public GameObject pokeballPrefab;
    public GameObject pokeball;

    public List<GameObject> pokeballList = new List<GameObject>();


    public GameObject GetNearestVictim()
    {
        float distance = -1;
        int index = -1;
        for(int i = 0; i< pokeballList.Count;i++)
        {
            float newDistance = Vector3.Distance(pokeballList[i].transform.position, transform.position);

            if (distance == -1 || newDistance < distance)
            {
                distance = newDistance;
                index = i;
            }
        }

        if (index != -1)
        {
            return pokeballList[index].GetComponent<Pokeball>().owner;
        }
        else 
        {
            return null;
        }
        

    }

    public Vector3 NewPos(float escapeDistance)
    {
        float x = Random.Range(ground.bounds.min.x, ground.bounds.min.x + ground.bounds.size.x);
        float z = Random.Range(ground.bounds.min.z, ground.bounds.min.z + ground.bounds.size.z);

        bool isValid = false;

        while (isValid == false)
        {
            x = Random.Range(ground.bounds.min.x, ground.bounds.min.x + ground.bounds.size.x);
            z = Random.Range(ground.bounds.min.z, ground.bounds.min.z + ground.bounds.size.z);

           

            bool isValidThisTime = true;

            if (Vector3.Distance(transform.position, new Vector3(x, transform.position.y, z)) < escapeDistance){
                isValidThisTime = false;
            }
            else
            {
                foreach (MeshRenderer plane in nonWalkable)
                {
                    if (((x > plane.bounds.min.x) && (x < plane.bounds.min.x + plane.bounds.size.x)) && ((z > plane.bounds.min.z) && (z < plane.bounds.min.z + plane.bounds.size.z)))
                    {
                        //print("Inside");
                        isValidThisTime = false;
                    }
                }
            }

            if (isValidThisTime == true)
            {
                isValid = true;
            }


        }

        return new Vector3(x, transform.position.y, z);
        //target.position = new Vector3(x, transform.position.y, z);
        //navMesh.destination = target.position;
    }

    public void HideTreasure()
    {
        pokeball.GetComponent<Animator>().SetTrigger("Throw");
        pokeball = null;
        hasTreasure = false;
    }

}

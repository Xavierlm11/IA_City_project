using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;
using System;

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

    [SerializeField]
    private GameObject[] hidingSpots;
    [SerializeField]
    private GameObject hidingSpot;

    [SerializeField]
    private GameObject[] goalSpots;
    [SerializeField]
    private GameObject distantGoal;

    [SerializeField]
    private GameObject victim;

    [SerializeField]
    private bool hasGoal = false;

    public Vector3 escapePos;

    public bool hasThrown;

    public GameObject currentVictim;

    public void Start()
    {
        hidingSpots = GameObject.FindGameObjectsWithTag("hide");

    }

    public GameObject GetNearestVictim()
    {
        float distance = -1;
        int index = -1;
        for(int i = 0; i < pokeballList.Count;i++)
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
        float x = UnityEngine.Random.Range(ground.bounds.min.x, ground.bounds.min.x + ground.bounds.size.x);
        float z = UnityEngine.Random.Range(ground.bounds.min.z, ground.bounds.min.z + ground.bounds.size.z);

        bool isValid = false;

        while (isValid == false)
        {
            x = UnityEngine.Random.Range(ground.bounds.min.x, ground.bounds.min.x + ground.bounds.size.x);
            z = UnityEngine.Random.Range(ground.bounds.min.z, ground.bounds.min.z + ground.bounds.size.z);

           

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
        pokeballList.Remove(pokeball);
        pokeball = null;
        hasTreasure = false;
        currentVictim = null;
        hasGoal = false;
    }

    public void DestroyTreasure()
    {
        
        pokeballList.Remove(pokeball);
        Destroy(pokeball);
        pokeball = null;
        hasTreasure = false;
        hasThrown = true;
        hasGoal = false;
        //currentVictim = null;
        //print("Destroyed");

    }

    public void Hide()
    {
        if(hasGoal == true)
        {
            return;
        }
        //Func<GameObject, float> distance =
        //    (hs) => Vector3.Distance(gameObject.transform.position,
        //                             hs.transform.position);
        //distantGoal = goalSpots.Select(
        //    ho => (distance(ho), ho)
        //    ).Max().Item2;

        float initialDistance = 0;
        int goalIndex = -1;
        for(int i = 0; i< goalSpots.Length; i++)
        {
            float currentGoalDistance = Vector3.Distance(gameObject.transform.position, goalSpots[i].transform.position);
            float currentVictimDistance = Vector3.Distance(victim.transform.position, goalSpots[i].transform.position);

            float currentTotalDistance = currentGoalDistance + currentVictimDistance;

            if (currentTotalDistance > initialDistance)
            {
                initialDistance = currentTotalDistance;
                goalIndex = i;

            }
        }


        


        //Vector3 dir = hidingSpot.transform.position - gameObject.transform.position;
        //Ray backRay = new Ray(hidingSpot.transform.position, -dir.normalized);
        //RaycastHit info;
        //hidingSpot.GetComponent<Collider>().Raycast(backRay, out info, 50f);
        //// gameObject.transform.Translate(info.point + dir.normalized);
        
        target.position = goalSpots[goalIndex].transform.position;
        escapePos = goalSpots[goalIndex].transform.position;
        //navMesh.destination = goalSpots[goalIndex].transform.position;
        hasGoal = true;
        //Seek(info.point + dir.normalized);



        //Func<GameObject, float> distance =
        //    (hs) => Vector3.Distance(gameObject.transform.position,
        //                             hs.transform.position);
        //hidingSpot = hidingSpots.Select(
        //    ho => (distance(ho), ho)
        //    ).Min().Item2;
        //Vector3 dir = hidingSpot.transform.position - gameObject.transform.position;
        //Ray backRay = new Ray(hidingSpot.transform.position, -dir.normalized);
        //RaycastHit info;
        //hidingSpot.GetComponent<Collider>().Raycast(backRay, out info, 50f);
        //// gameObject.transform.Translate(info.point + dir.normalized);

        //target.position = info.point + dir.normalized;
        //navMesh.destination = info.point + dir.normalized;
        ////Seek(info.point + dir.normalized);
    }

}

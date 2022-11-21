using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SalaryMan : MonoBehaviour
{
    public NavMeshAgent navMesh;
    public Transform target;

    [SerializeField] private List<MeshRenderer> nonWalkable;
    [SerializeField] private MeshRenderer ground;

    public float targetRadius;


    public GameObject pokeballParent;
    public GameObject pokeballPrefab;
    public GameObject pokeball;
    public GameObject thief;

    public bool hasRealized;

    [SerializeField] private GameObject cop;
    [SerializeField] private float screamRadius;

    public bool hasChecked = false;

    public void SpawnTreasure()
    {
        pokeball = Instantiate(pokeballPrefab, pokeballParent.transform);
        pokeball.GetComponent<Pokeball>().owner = transform.gameObject;
        thief.GetComponent<Thief>().pokeballList.Add(pokeball);
       
        Debug.Log("Spawneedd");
    }

    public bool CheckRealize()
    {

        bool hasRealizedCopy = hasRealized;
        if (hasChecked == false)
        {

            int num = Random.Range(0, 2);

                if (num == 0)
                {
                    hasRealizedCopy = true;
                    hasRealized = true;
                    Realize();
                    Debug.Log("Realized");
                }
                else
                {
                    hasRealizedCopy = false;
                    hasRealized = false;
                    Debug.Log("Not Realized");
                    //victim.GetComponent<SalaryMan>().hasChecked = true;
                }

            hasChecked = true;
        }

        return hasRealizedCopy;
    }

    public void Realize()
    {
        //hasChecked = true;
        //hasRealized = true;
        //gameObject.GetComponent<Animator>().SetBool("IsIdle", true);
        if (Vector3.Distance(cop.transform.position, transform.position) < screamRadius)
        {
            cop.GetComponent<Policeman>().Realize();
            //print("SCREAAAAAAMM");
            Stop();
        }
    }

    public void Stop()
    {
        print("Stay Init");
        
        StartCoroutine("Stay");
       
        print("Stay Final");
        //hasChecked = true;
    }

    IEnumerator Stay()
    {
        //target.position = gameObject.transform.position;
        gameObject.GetComponent<Animator>().SetBool("IsIdle", true);
        gameObject.GetComponent<NavMeshAgent>().isStopped = true;
        yield return new WaitForSeconds(3);
        gameObject.GetComponent<Animator>().SetBool("IsIdle", false);
        gameObject.GetComponent<NavMeshAgent>().isStopped = false;
        hasRealized = false;
    }


    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();

        SpawnTreasure();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(target.position, targetRadius);

        Gizmos.DrawWireSphere(transform.position, screamRadius);
    }

}

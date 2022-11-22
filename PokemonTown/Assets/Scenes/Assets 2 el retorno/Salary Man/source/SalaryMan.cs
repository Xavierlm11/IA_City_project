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
    }

    public bool CheckRealize()
    {

        bool hasRealizedCopy = hasRealized;
        if (hasChecked == false)
        {

            int num = Random.Range(0, 100);

                if (num < 60)
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
                }

            hasChecked = true;
        }

        return hasRealizedCopy;
    }

    public void Realize()
    {
        if (Vector3.Distance(cop.transform.position, transform.position) < screamRadius)
        {
            cop.GetComponent<Policeman>().Realize();
            Stop();
        }
    }

    public void Stop()
    {
        StartCoroutine("Stay");
    }

    IEnumerator Stay()
    {
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

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, screamRadius);
    }

}

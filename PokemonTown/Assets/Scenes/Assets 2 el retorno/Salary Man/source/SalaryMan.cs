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

    public void SpawnTreasure()
    {
        pokeball = Instantiate(pokeballPrefab, pokeballParent.transform);
        pokeball.GetComponent<Pokeball>().owner = transform.gameObject;
        thief.GetComponent<Thief>().pokeballList.Add(pokeball);
        Debug.Log("Spawneedd");
    }

    public void Realize()
    {
        hasRealized = true;
        if (Vector3.Distance(cop.transform.position, transform.position) < screamRadius)
        {
            cop.GetComponent<Policeman>().Realize();
            print("SCREAAAAAAMM");
        }
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

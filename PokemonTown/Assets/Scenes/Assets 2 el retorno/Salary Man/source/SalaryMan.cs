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

    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        pokeball = Instantiate(pokeballPrefab, pokeballParent.transform);
        pokeball.GetComponent<Pokeball>().owner = transform.gameObject;
        thief.GetComponent<Thief>().pokeballList.Add(pokeball);
       
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(target.position, targetRadius);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diglett : MonoBehaviour
{
    [SerializeField] private float freq;
    private float activeTime;

    [SerializeField] private GameObject ground;

    void Start()
    {
        
    }

    void Update()
    {
        activeTime += Time.deltaTime;
        if (activeTime > freq)
        {
            activeTime -= freq;

            Appear();
        }
    }

    private void Appear()
    {
        //float x = Random.RandomRange(ground.GetComponent<BoxCollider>().bounds.x bounds.center- ground.GetComponent<MeshCollider>().bounds.);
    }

}

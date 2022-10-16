using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    // Start is called before the first frame update 
    //public GameObject allFish;
    [SerializeField] public int numFish;
    [SerializeField] private int min,max;
    public int minSpeed, maxSpeed;
    public float rotationSpeed;
    public GameObject fishPrefab;
    public GameObject[] allFish;
    [SerializeField] public int neighbourDistance;
    void Start()
    {
        allFish = new GameObject[numFish];
        
            for (int i = 0; i < numFish; ++i)
            {
                Vector3 pos = this.transform.position + new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max)); // random position
                Vector3 randomize = new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max)); // random vector direction
            
                allFish[i] =(GameObject)Instantiate(fishPrefab, pos, Quaternion.LookRotation(randomize));
                allFish[i].GetComponent<Flock>().myManager = this;
            }
    }
    
  
    
    // Update is called once per frame
    void Update()
    {
        
        
    }
}

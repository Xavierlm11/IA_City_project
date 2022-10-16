using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerManager : MonoBehaviour
{
    public GameObject runner;
    public Transform runnerFolder;
    public Transform runnerSpawn;
    public int runnerNum;
    public float minSpeedRange;
    public float maxSpeedRange;
    public float minPosRange;
    public float maxPosRange;

    public List<GameObject> targets;
    public List<GameObject> runnerList;

    public FlockingManager flockManager;
    public float beeDistance;
    public float runAwayScale;

    void Start()
    {
        for (int i = 0 ; i < runnerNum; i++){

            GameObject newRunner = Instantiate(runner, runnerFolder);

            Vector3 randomPos = new Vector3(Random.Range(minPosRange, maxPosRange), Random.Range(minPosRange, maxPosRange), 0);
            newRunner.transform.position = runnerSpawn.position + randomPos;

            newRunner.GetComponent<Runner>().speed = Random.Range(minSpeedRange, maxSpeedRange);
            newRunner.GetComponent<Runner>().targets = targets;
            newRunner.GetComponent<Runner>().runnerManager = this;
            newRunner.GetComponent<Runner>().flockManager = flockManager;
            runnerList.Add(newRunner);
        }
    }

    void Update()
    {
        
    }
}

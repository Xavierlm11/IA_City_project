using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerSpawn : MonoBehaviour
{
    public GameObject runner;
    public Transform runnerFolder;
    public Transform runnerSpawn;
    public int runnerNum;
    public int minSpeedRange;
    public int maxSpeedRange;
    public int minPosRange;
    public int maxPosRange;

    public List<GameObject> targets;

    void Start()
    {
        for (int i = 0 ; i < runnerNum; i++){

            GameObject newRunner = Instantiate(runner, runnerFolder);

            Vector3 randomPos = new Vector3(Random.Range(minPosRange, maxPosRange), Random.Range(minPosRange, maxPosRange), 0);
            newRunner.transform.position = runnerSpawn.position + randomPos;

            newRunner.GetComponent<Runner>().speed = Random.Range(minSpeedRange, maxSpeedRange);
            newRunner.GetComponent<Runner>().targets = targets;
        }
    }

    void Update()
    {
        
    }
}

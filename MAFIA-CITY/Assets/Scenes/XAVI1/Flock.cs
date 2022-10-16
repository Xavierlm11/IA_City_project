using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public Manager myManager;
    Vector3 cohesion = Vector3.zero;
    int num = 0;
    [SerializeField] private float speed;
    Vector3 align = Vector3.zero;
    Vector3 separation = Vector3.zero;
    Vector3 direction ;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        Flock1();
        Flock2();
        Flock3();

        direction = (cohesion + align + separation).normalized * speed;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), myManager.rotationSpeed * Time.deltaTime);
        transform.Translate(0.0f, 0.0f, Time.deltaTime * speed);
    }

    private void Flock3()
    {
        foreach (GameObject go in myManager.allFish)
        {
            if (go != this.gameObject)
            {
                float distance = Vector3.Distance(go.transform.position, transform.position);
                if (distance <= myManager.neighbourDistance)
                {
                    align += go.GetComponent<Flock>().direction;
                    num++;
                }
            }
        }
        if (num > 0)
        {
            align /= num;
            speed = Mathf.Clamp(align.magnitude, myManager.minSpeed, myManager.maxSpeed);
        }
    }

    private void Flock2()
    {
        num =0;
        foreach (GameObject go in myManager.allFish)
        {
            if (go != this.gameObject)
            {
                float distance = Vector3.Distance(go.transform.position, transform.position);
                if (distance <= myManager.neighbourDistance)
                {
                    align += go.GetComponent<Flock>().direction;
                    num++;
                }
            }
        }
        if (num > 0)
        {
            align /= num;
            speed = Mathf.Clamp(align.magnitude, myManager.minSpeed, myManager.maxSpeed);
        }
    }

    private void Flock1()
    {
        num = 0;
        foreach (GameObject go in myManager.allFish)
        {
            if (go != this.gameObject)
            {
                float distance = Vector3.Distance(go.transform.position,
                                                  transform.position);
                if (distance <= myManager.neighbourDistance)
                {
                    cohesion += go.transform.position;
                    num++;
                }
            }
        }
        if (num > 0)
            cohesion = (cohesion / num - transform.position).normalized * speed;
    }
}

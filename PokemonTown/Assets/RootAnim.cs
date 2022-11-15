using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootAnim : MonoBehaviour
{
    public Vector3 transformPos;
    void Start()
    {
      //  transformPos = transform.position;
    }

    void Update()
    {
        transform.localPosition = new Vector3(0, 0, 0);
    }
}

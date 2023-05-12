using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGroundType : MonoBehaviour
{
    [SerializeField] private FootStep footstepObject;

    void OnCollisionEnter(Collision col)
    {
        switch (col.gameObject.tag)
        {
            case "Grass":
            case "Road":
            case "Water":
                footstepObject.groundType = col.gameObject.tag;
                break;

            default:
                break;
        }
    }
}

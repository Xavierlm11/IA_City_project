using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AmbientSwap : MonoBehaviour
{
    [SerializeField] private AudioMixerSnapshot outdoorSnap;
    [SerializeField] private AudioMixerSnapshot indorSnap;

    [SerializeField] private float transitionTime = 0.25f;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Center") 
        { 
            indorSnap.TransitionTo(transitionTime); 
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Center")
        {
            outdoorSnap.TransitionTo(transitionTime);
        }
    }
}

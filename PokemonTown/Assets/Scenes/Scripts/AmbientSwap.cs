using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AmbientSwap : MonoBehaviour
{
    [SerializeField] private AudioMixerSnapshot outdoorSnap;
    [SerializeField] private AudioMixerSnapshot indorSnap;
    [SerializeField] private AudioMixerSnapshot atentionSnap;

    [SerializeField] private float transitionTime = 0.25f;
    [SerializeField] private float fastTransitionTime = 0.25f;
    [SerializeField] private float slowTransitionTime = 0.25f;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Center") 
        { 
            indorSnap.TransitionTo(slowTransitionTime); 
        }
         if (collider.tag == "Atention") 
        {
            atentionSnap.TransitionTo(transitionTime); 
        }
        

    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Center")
        {
            outdoorSnap.TransitionTo(transitionTime);
        }
        if (collider.tag == "Atention")
        {
            outdoorSnap.TransitionTo(transitionTime);
        }
    }
}

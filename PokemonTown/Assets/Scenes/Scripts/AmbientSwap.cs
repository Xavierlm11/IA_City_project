using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AmbientSwap : MonoBehaviour
{
    [SerializeField]private AudioMixerSnapshot outdoorSnap;
    [SerializeField]private AudioMixerSnapshot indorSnap;

    public float transitionTime = 0.25f;

    void OnTriggerEnter(Collider collider)
    {
        indorSnap.TransitionTo(transitionTime);
    }

    void OnTriggerExit(Collider collider)
    {
        outdoorSnap.TransitionTo(transitionTime);
    }
}

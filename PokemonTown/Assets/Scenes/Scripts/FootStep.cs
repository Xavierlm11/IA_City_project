using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStep : MonoBehaviour
{
    [SerializeField] private AudioClip[] footstepsOnGrass;
    [SerializeField] private AudioClip[] footstepsOnPlant;
    [SerializeField] private AudioClip[] footstepsOnRoad;
    [SerializeField] private AudioClip[] footstepsOnWater;
    [SerializeField] private AudioClip[] footstepsOnCenter;

    public string groundType;

    void FootStepSound() 
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.volume = Random.Range(0.9f, 1.0f);
        audioSource.pitch = Random.Range(0.9f, 1.1f);

        switch (groundType)
        {
            case "Grass":
                if (footstepsOnGrass.Length > 0)
                {
                    audioSource.PlayOneShot(footstepsOnGrass[Random.Range(0, footstepsOnGrass.Length)]);
                }
                break;

            case "Plant":
                if (footstepsOnPlant.Length > 0)
                {
                    audioSource.PlayOneShot(footstepsOnPlant[Random.Range(0, footstepsOnPlant.Length)]);
                }
                break;

            case "Road":
                if (footstepsOnRoad.Length > 0)
                {
                    audioSource.PlayOneShot(footstepsOnRoad[Random.Range(0, footstepsOnRoad.Length)]);
                }
                break;

            case "Water":
                if (footstepsOnWater.Length > 0)
                {
                    audioSource.PlayOneShot(footstepsOnWater[Random.Range(0, footstepsOnWater.Length)]);
                }
                break;

            case "Center":
                if (footstepsOnCenter.Length > 0)
                {
                    audioSource.PlayOneShot(footstepsOnCenter[Random.Range(0, footstepsOnCenter.Length)]);
                }
                break;

            default:

                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStep : MonoBehaviour
{
    [SerializeField] private AudioClip[] footstepsOnGrass;
    [SerializeField] private AudioClip[] footstepsOnPath;

    private string groundType;

    void FootStepSound() 
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.volume = Random.Range(0.8f, 1.2f);
        audioSource.pitch = Random.Range(0.8f, 1.2f);

        switch (groundType)
        {
            case "Grass":
                if (footstepsOnGrass.Length > 0)
                {
                    audioSource.PlayOneShot(footstepsOnGrass[Random.Range(0, footstepsOnGrass.Length)]);
                }
                break;

            case "Path":
                if (footstepsOnPath.Length > 0)
                {
                    audioSource.PlayOneShot(footstepsOnPath[Random.Range(0, footstepsOnPath.Length)]);
                }
                break;

            default:

                break;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        switch (col.gameObject.tag)
        {
            case "Grass":
            case "Path":
                groundType = col.gameObject.tag;
                break;

            default:
                break;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diglett : MonoBehaviour
{
    [SerializeField] private float freqUp;
    [SerializeField] private float freqDown;
    private float activeTime;

    [SerializeField] private MeshRenderer ground;

    private bool hasToAppear;
    private bool hasToDisappear;

    [SerializeField] private AnimationClip appearAnim;
    [SerializeField] private AnimationClip disappearAnim;
    [SerializeField] private Animator anim;

    private bool isUp;

    void Start()
    {
        
    }

    void Update()
    {
        if (isUp == true)
        {
            activeTime += Time.deltaTime;
            if (activeTime > freqUp)
            {
                activeTime -= freqUp;

                Disappear();
            }


            if (hasToDisappear == true)
            {
                CheckDisappear();
            }
        }
        else
        {
            activeTime += Time.deltaTime;
            if (activeTime > freqDown)
            {
                activeTime -= freqDown;

                Appear();
            }

            if (hasToAppear == true)
            {
                CheckAppear();
            }
        }

    }

    private void Disappear()
    {
        
        hasToDisappear = true;
        
    }

    private void Appear()
    {

        hasToAppear = true;

    }

    private void CheckAppear() 
    {       
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Appear") == true)
        {
            if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            {
                hasToAppear = false;
                isUp = true;
            }
        }
        else
        {
            anim.Play("Appear");
        }
    }

    private void CheckDisappear()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Disappear") == true)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            {
                hasToDisappear = false;
                isUp = false;
                NewPos();
            }
        }
        else
        {
            anim.Play("Disappear");
        }
    }

    private void NewPos()
    {
        float x = Random.Range(ground.localBounds.min.x, ground.localBounds.extents.x);
        float y = ground.transform.localPosition.y;
        float z = Random.Range(ground.localBounds.min.z, ground.localBounds.extents.z);

        transform.localPosition = new Vector3(x, y, z);
    }

}

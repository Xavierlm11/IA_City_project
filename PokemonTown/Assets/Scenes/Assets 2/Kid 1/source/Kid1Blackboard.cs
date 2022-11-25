using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Kid1Blackboard : MonoBehaviour
{
    // Start is called before the first frame update
    public bool _IsTouched = false;
    public bool _CanTouched = false ; 
   

    public void IsTouched()
    {
        _IsTouched = true;
    }

    public void IsntTouched()
    {
        _IsTouched = false;
    }

    public void CanTouch()
    {
        _CanTouched = true;
    }

    public void CantTouch()
    {
        _CanTouched = false;
    }
    public void Stop()
    {
        StartCoroutine("Stay");
    }

    IEnumerator Stay()
    {
        //gameObject.GetComponent<Animator>().SetTrigger("IsTouched");
        gameObject.GetComponent<NavMeshAgent>().isStopped = true;
        yield return new WaitForSeconds(5);
        //gameObject.GetComponent<Animator>().SetTrigger("Run");
        gameObject.GetComponent<NavMeshAgent>().isStopped = false;
        CanTouch();

    }
}

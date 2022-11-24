using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}

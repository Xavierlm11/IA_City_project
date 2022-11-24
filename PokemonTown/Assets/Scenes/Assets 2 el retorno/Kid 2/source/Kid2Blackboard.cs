using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kid2Blackboard : MonoBehaviour
{
    public bool _IsTouched;
    public bool _CanTouched;

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

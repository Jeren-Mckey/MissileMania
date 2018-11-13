using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public delegate void TouchAction();
    public static event TouchAction onTouched;

    public void OnTouched()
    {
        if (Input.touchCount > 0)
        { 
            if (onTouched != null)
            {
                onTouched();
            }
        }
    }
}


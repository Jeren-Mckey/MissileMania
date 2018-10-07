using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEventManager : MonoBehaviour {

    public delegate void TouchAction(Vector2 myTouch);
    public static event TouchAction onTouch;

    public void OnTouch()
    {
        if (onTouch != null)
        {
            Vector2 myTouch = Input.GetTouch(0).deltaPosition;
            onTouch(myTouch);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherVector : MonoBehaviour {

	void OnEnable()
    {
        RotateEventManager.onTouch += RotatePivot;
    }

    void OnDisable()
    {
        RotateEventManager.onTouch -= RotatePivot;
    }

    public void RotatePivot(Vector2 myTouch)
    {
        gameObject.transform.rotation = Quaternion.Euler(0f, myTouch.x * 1.0f, 0f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherVector : MonoBehaviour {

    void Start()
    {
       
    }
	void Update()
    { 
        if (Input.touchCount > 0)
        {
            Touch myTouch = Input.touches[0];
            if (myTouch.phase == TouchPhase.Began)
            {
                Vector3 touchPos = myTouch.position;
                touchPos = Camera.main.ScreenToWorldPoint(touchPos);
                Vector2 direction = new Vector2(
                    touchPos.x - transform.position.x,
                    touchPos.y - transform.position.y);
                if (direction.y < 2.50f) direction.y = 2.50f;
                transform.up = direction;
            }
        }
    }
}

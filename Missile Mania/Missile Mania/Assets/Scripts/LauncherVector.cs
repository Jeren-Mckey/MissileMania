﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class LauncherVector : MonoBehaviour {

    public GameObject missilePrefab;
    private static float lastTime;
    private float currentTime;
    void Start()
    {
        lastTime = 0;
        currentTime = 0;
    }
	void Update()
    {
        currentTime = Time.time;
        if (Input.touchCount > 0)
        {
            Touch myTouch = Input.touches[0];
            if ((myTouch.phase == TouchPhase.Began) && ((currentTime - lastTime >= .3f) || (lastTime == 0)))
            {
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    Vector3 touchPos = myTouch.position;
                    touchPos = Camera.main.ScreenToWorldPoint(touchPos);
                    Vector2 direction = new Vector2(
                        touchPos.x - gameObject.transform.position.x,
                        touchPos.y - gameObject.transform.position.y);
                    if (direction.y < .5f){
                        direction.y = 1f;
                        if (direction.x >= transform.position.x) direction.x = 10f;
                        else if (direction.x <= transform.position.x) direction.x = -10f;
                    }
                    gameObject.transform.up = direction;
                    Instantiate(missilePrefab, transform.position, Quaternion.identity).SendMessage("theStart", myTouch);
                    lastTime = currentTime;
                }
            }
        }
    }

    public static float getTimeSince()
    {
        return lastTime;
    }
}

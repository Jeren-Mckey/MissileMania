﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float startTime;
    private float newTime;
    private float spawnFastTime;
    private float speed;
    private bool upDifficulty;
    public Text text;
    private float elapsedTime;
    public GameObject enemy_missile_prefab;
    public GameObject enemy_parachuter;
    public Slider slider;
    public Button triggerStrike;   //reference for button

    public void OnEnable()
    {
        EventManager.onHit += addProgress;
    }
    // Use this for initialization
    void Start () {
        startTime = Time.time; //Time since start or since last difficulty change
        newTime = Time.time; //Time between missile drops
        elapsedTime = 1.6f; //How long before each missile drops
        speed = 2.8f; //Speed of the rocket
        spawnFastTime = 5f; //How long between spawning of fast rocket
        upDifficulty = false;
        gameObject.GetComponent<CameraShake>().enabled = false;
        //triggerStrike.gameObject.SetActive(false);
        slider.value = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if ((Time.time - newTime) > elapsedTime)
        {
            dropMissile(speed);
            newTime = Time.time;
        }
        if (Time.time - startTime >= 18f && !upDifficulty)
        {
            upDifficulty = true; //After 15 seconds start spawning fast missiles
        }
        if ((Time.time - startTime) > spawnFastTime && SceneManager.GetActiveScene().name ==
            "MainScene" && upDifficulty)
        {
            dropMissile(speed * 2 - 1f);
            if (elapsedTime >= 1f)
            {
                elapsedTime = elapsedTime - .1f;
            }
            startTime = Time.time;
        }
        if (SceneManager.GetActiveScene().name == "MainScene") text.text = GlobalControl.getPoints().ToString();
   	}

    public void dropMissile(float newSpeed)
    {
        float spawnY = Random.Range
            (Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height + 100)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height + 100)).y);
        float spawnX = Random.Range
            (Camera.main.ScreenToWorldPoint(new Vector2(15, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width - 15, 0)).x);
        Vector2 spawnPosition = new Vector2(spawnX, spawnY);
        Instantiate(enemy_missile_prefab, spawnPosition, Quaternion.identity).SendMessage("startDrop", newSpeed);
        newTime = Time.time;
    }

    public void addProgress()
    {
        //if player triggers fire object and health is greater than 0
        if(slider.value < 100){
            slider.value += 5f;  //increase progress to explosion
        }
        else{ 
            triggerStrike.gameObject.SetActive(true);
        }
    }

    public void OnDisable()
    {
        EventManager.onHit -= addProgress;
    }
}

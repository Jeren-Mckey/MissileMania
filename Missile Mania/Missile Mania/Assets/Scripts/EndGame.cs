using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

    private int add_miss;
    private float wait;
    private int counter;
    private float time;
    private float elapsedTime;
    private bool started;
    public Text text;
	// Use this for initialization
	void Start ()
    {
        add_miss = 0;
        counter = 0;
        elapsedTime = .6f;
        started = false;
        time = -1f;
        gameObject.GetComponent<CameraShake>().enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        if (add_miss >= 3 && !(Time.fixedTime >= (wait + .75)))
        {
            counter++;
        }
        else if (add_miss >= 3 &&  (Time.fixedTime >= (wait + .75)))
        {
            SceneManager.LoadScene("EndScreen");
        } 
        else if (GlobalControl.getPoints() == 200 && (Time.fixedTime >= (wait + .75)))
        {
            SceneManager.LoadScene("WinnerScene");
        }
        else wait = Time.fixedTime;
        if (started)
        {
            if (time == -1f) time = Time.time;
            if (Time.time - time >= elapsedTime){
                gameObject.GetComponent<CameraShake>().enabled = false; 
                time = -1f;
                started = false;
               }
        }      
        
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "enemy_missile_prefab(Clone)")
        {
            add_miss++;
            gameObject.GetComponent<CameraShake>().enabled = true;
                started = true;
            if (SceneManager.GetActiveScene().name == "MainScene")
                text.text = add_miss.ToString();  
        }
    }
}

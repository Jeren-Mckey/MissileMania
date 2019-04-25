using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

    private int add_miss;
    private float wait;
    private int counter;
    public Text text;
	// Use this for initialization
	void Start ()
    {
        add_miss = 0;
        counter = 0;
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
        else wait = Time.fixedTime;
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "enemy_missile_prefab(Clone)")
        {
            add_miss++;
            if (SceneManager.GetActiveScene().name == "MainScene")
                text.text = add_miss.ToString();   
        }
    }
}

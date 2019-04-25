using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scores : MonoBehaviour {
    public static int points;

	// Use this for initialization
	void Start ()
    {
        points = 0;
        DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public static void addPoints(int num)
    {
        points = num;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPoints : MonoBehaviour {

    public Text text;
    private int points;
	// Use this for initialization
	void Start () {
        points = Scores.points;
        text.text = points.ToString();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}

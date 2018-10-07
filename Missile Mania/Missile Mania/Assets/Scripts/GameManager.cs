using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float _points;

    public float Points
    {
        get { return _points; }
        set { _points = value; }
    }

    // Use this for initialization
    void Start () {
        Points = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

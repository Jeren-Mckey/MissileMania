using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float _points;
    private float startTime;
    private float elapsedTime;
    public GameObject enemy_missile_prefab;

    public float Points
    {
        get { return _points; }
        set { _points = value; }
    }

    // Use this for initialization
    void Start () {
        Points = 0;
        startTime = Time.time;
        elapsedTime = 2f;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if ((Time.time - startTime) > elapsedTime)
        {
            float spawnY = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height + 70)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height + 90)).y);
            float spawnX = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(20, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width - 20, 0)).x);
            Vector2 spawnPosition = new Vector2(spawnX, spawnY);
            Instantiate(enemy_missile_prefab, spawnPosition, Quaternion.identity).SendMessage("startDrop");
            startTime = Time.time;
        }

	}
}

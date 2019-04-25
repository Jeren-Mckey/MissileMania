using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissileDrop : MonoBehaviour {

    private Vector3 movementVector;
    public GameObject Explosion;
    private bool isTriggered;
    private Vector2 positionVector;

    // Use this for initialization
    void Start ()
    {
        isTriggered = false;
        DestroyMissile(30);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isTriggered)
        {
            Instantiate(Explosion, transform.position, Quaternion.identity);
            isTriggered = false;
            DestroyMissile();
        }
        transform.position += (movementVector * Time.deltaTime);
        transform.up = movementVector;
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Floor")
        {
            isTriggered = true;
        }
        else if (col.gameObject.tag != "enemy") DestroyMissile();
    }

    public void DestroyMissile()
    {
        Destroy(gameObject);
    }

    public void DestroyMissile(float time)
    {
        Destroy(gameObject, time);
    }

    void startDrop(float speed)
    {
        positionVector = (-Vector2.up);
        movementVector = positionVector.normalized * speed;
    }
}

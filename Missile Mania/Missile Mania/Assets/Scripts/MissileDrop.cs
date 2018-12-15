using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileDrop : MonoBehaviour {

    private Vector3 movementVector;
    public float speed;
    private Vector2 positionVector;

    // Use this for initialization
    void Start ()
    {
 
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += (movementVector * Time.deltaTime);
        transform.up = movementVector;
        //OnCollisionEnter2D(collider1);
        DestroyMissile(15.0f);
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        // if (col.gameObject.name == "Base_Missile_Prefab")
        //{
            DestroyMissile();
       // }
    }

    public void DestroyMissile()
    {
        Destroy(gameObject);
    }

    public void DestroyMissile(float time)
    {
        Destroy(gameObject, time);
    }

    void startDrop()
    {
        positionVector = (-Vector2.up);
        movementVector = positionVector.normalized * speed;
    }
}

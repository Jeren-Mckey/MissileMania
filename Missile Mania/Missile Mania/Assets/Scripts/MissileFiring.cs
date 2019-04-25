using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MissileFiring : MonoBehaviour {

    public GameObject Explosion;
    private bool isTriggered;
    private Vector3 movementVector;
    public float speed;
    private Vector3 touchPos;

    // Use this for initialization
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggered)
        {
            Instantiate(Explosion, transform.position, Quaternion.identity);
            isTriggered = false;
            DestroyMissile();
        }
        transform.Rotate(Vector3.forward * -90);
        transform.position += (movementVector * Time.deltaTime);
        transform.up = movementVector;
        DestroyMissile(3.0f);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("enemy"))
        {
            GameManager.addPoints();
            isTriggered = true;
        }
    }

    public void DestroyMissile()
    {
        
        Destroy(gameObject);
    }

    public void DestroyMissile(float time)
    {
        Destroy(gameObject, time);
    }

    public void theStart(Touch myTouch)
    {   if (LauncherVector.getTimeSince() - Time.time < .5)
        {
            touchPos = myTouch.position;
            touchPos = Camera.main.ScreenToWorldPoint(touchPos);
            movementVector = new Vector2(
                    touchPos.x - transform.position.x,
                    touchPos.y - transform.position.y).normalized * speed;
            if (movementVector.y < 2f) movementVector.y = 2f;
        }
    }
}


using UnityEngine;

public class MissileFiring : MonoBehaviour {

    public Transform missileSpawn;
    public Vector2 target;
    public Vector3 movementVector;
    public float speed;
    public Vector3 touchPos;

    // Use this for initialization
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * -90);
        transform.position += (movementVector * Time.deltaTime);
        transform.up = movementVector;
        DestroyMissile(3.0f);
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "enemy_missile_prefab")
        {
            DestroyMissile();
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
    {   
        touchPos = myTouch.position;
        touchPos = Camera.main.ScreenToWorldPoint(touchPos);
        target = new Vector2(touchPos.x, touchPos.y);
        movementVector = new Vector2(
                    touchPos.x - transform.position.x,
                    touchPos.y - transform.position.y).normalized * speed;
    }
}


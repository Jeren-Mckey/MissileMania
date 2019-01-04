using UnityEngine;

public class MissileFiring : MonoBehaviour {

    private Vector2 target;
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
    {   
        touchPos = myTouch.position;
        touchPos = Camera.main.ScreenToWorldPoint(touchPos);
        target = new Vector2(touchPos.x, touchPos.y);
        movementVector = new Vector2(
                    touchPos.x - transform.position.x,
                    touchPos.y - transform.position.y).normalized * speed;
    }
}


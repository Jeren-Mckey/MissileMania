using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltraDefense : MonoBehaviour
{
    public float expansionRate;
    private float elapsedTime;
    private float time;
    private Vector3 baseScale;
    private float endTime;
    private bool growing;
    // Start is called before the first frame update
    void Start()
    {
        baseScale = transform.localScale;
        growing = false;
        time = Time.time;
        elapsedTime = .1f;
        endTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Time.time - time) >= elapsedTime && growing)
        {
            time = Time.time;
            endTime += .1f;
            transform.localScale += new Vector3(5F, 5F, 5F);
        }
        if (endTime >= .8f)
        {
            growing = false;
            endTime = 0;
            transform.localScale = baseScale;
        }
    }

    public void startGrowing()
    {
        growing = true;
    }

}

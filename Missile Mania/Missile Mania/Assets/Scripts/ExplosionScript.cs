using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour {

    private Animator anim;
    private AnimatorStateInfo info;
    private bool hasPlayed;
	// Use this for initialization
	void Start ()
    {
        anim = gameObject.GetComponent<Animator>();
        anim.SetTrigger("StartExplosion");
        
        hasPlayed = false;
    }

    // Update is called once per frame
    void Update ()
    {
        info = anim.GetCurrentAnimatorStateInfo(0);
        if (info.IsName("Explosion") && !hasPlayed)
        {
            hasPlayed = true;
        }
        if (info.IsName("Default") && hasPlayed)
        {
            Destroy(gameObject);
        }
       // else hasPlayed = ;
    }
}

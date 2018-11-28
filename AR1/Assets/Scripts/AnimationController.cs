using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    public Animation anim;
    public GameObject animation;

    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        anim["bike"].layer = 123;

        gameObject.GetComponent<Animator>().Play("BaseLayer.bike");

    }

    // Update is called once per frame
    void Update () {
        if (anim.isPlaying)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Spinning");
            anim.Play("bike");
        }

    }
}

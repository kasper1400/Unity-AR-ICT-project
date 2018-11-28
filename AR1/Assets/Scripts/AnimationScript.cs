using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour {

    public Animation anim;

    void Start()
    {
        //gameObject.GetComponent<Animator>().Play("bike");
        anim = GetComponent<Animation>();

    }

    // Update is called once per frame
    void Update () {
        anim.Play("bike");
    }
}

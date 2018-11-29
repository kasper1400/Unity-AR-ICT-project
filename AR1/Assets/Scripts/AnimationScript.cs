using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour {

    //public Animation anim;
    public Animation animat;
    public GameObject bench;
    public GameObject bike;

    void Start()
    {
        // anim = GetComponent<Animation>();
        // animat = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update () {
        //animat.Play("bench");
        bike.GetComponent<Animation>().Play("bike");
        bench.GetComponent<Animation>().Play("bench");

        //anim.Play("bike");
    }
}

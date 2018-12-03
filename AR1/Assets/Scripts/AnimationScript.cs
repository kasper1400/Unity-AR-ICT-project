using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationScript : MonoBehaviour {

    //public Animation anim;
    public Animation animat;
    public GameObject bench;
    public GameObject bike;
    public GameObject text1;
    public bool IsTextActive;


    void Start()
    {
      
        bike.SetActive(false);
        bench.SetActive(false);
        //IsTextActive = true;
        // anim = GetComponent<Animation>();
        // animat = GetComponent<Animation>();
        // bench.SetActive(false);

    }

    // Update is called once per frame
    void Update () {
        //animat.Play("bench");
        bike.GetComponent<Animation>().Play("bike");
        bench.GetComponent<Animation>().Play("bench");

        //anim.Play("bike");
    }
    public void ShowBike()
    {
        bike.SetActive(true);

    }
    public void ShowBench()
    {
        //bench.SetActive(!bench.activeSelf);

        if (IsTextActive == true)
        {


            bench.SetActive(false);

            text1.GetComponent<Text>().text = "Learn from Character";
            IsTextActive = false;
        }

        else if (IsTextActive == false)
        {
            bench.SetActive(true);

            text1.GetComponent<Text>().text = "Hide Character";

            IsTextActive = true;

        }
    }
}



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
    public GameObject BikeText;
    public bool IsTextActive;
    public GameObject lookleft;


    void Start()
    {
        lookleft.SetActive(false);
        //bike.SetActive(true);
        //bench.SetActive(false);
        IsTextActive = true;
    }

    // Update is called once per frame
    void Update () {
        bike.GetComponent<Animation>().Play("bike");
        bench.GetComponent<Animation>().Play("bench");
    }

    public void ShowBike()
    {
        bike.SetActive(!bike.activeSelf);

        if (IsTextActive == true)
        {
            text1.GetComponent<Text>().text = "Learn from Character";
            lookleft.SetActive(false);
            IsTextActive = false;
        }

        else if (IsTextActive == false)
        {
            text1.GetComponent<Text>().text = "Hide Character";
            lookleft.SetActive(true);
            IsTextActive = true;

        }

    }

    public void ShowBench()
    {
        bench.SetActive(!bench.activeSelf);

        if (IsTextActive == true)
        {
            text1.GetComponent<Text>().text = "Learn from Character";
            IsTextActive = false;
        }

        else if (IsTextActive == false)
        {
            text1.GetComponent<Text>().text = "Hide Character";
            IsTextActive = true;

        }
    }
}



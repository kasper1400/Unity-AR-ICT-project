using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationScript : MonoBehaviour {

    //public Animation anim;
    public Animation animat;
    public GameObject bench;
    public GameObject bike;
    public GameObject BenchText;
    public GameObject BikeText;
    public bool IsTextActiveBike;
    public bool IsTextActiveBench;
    public GameObject lookleftbench;
    public GameObject lookleftbike;

    
    void Start()
    {
        //lookleftbench.SetActive(false);
       // lookleftbike.SetActive(false);
        //bike.SetActive(true);
        //bench.SetActive(false);
        IsTextActiveBench = true;
        IsTextActiveBike = true;
       

    }
   

    // Update is called once per frame
    void Update () {
        bike.GetComponent<Animation>().Play("bike");
        bench.GetComponent<Animation>().Play("bench");
    }

    public void ShowBike()
    {
        bike.SetActive(!bike.activeSelf);

        if (IsTextActiveBike == true)
        {
            BikeText.GetComponent<Text>().text = "Learn from Character";
            lookleftbike.SetActive(false);
            IsTextActiveBike = false;
        }

        else if (IsTextActiveBike == false)
        {
            BikeText.GetComponent<Text>().text = "Hide Character";
            lookleftbike.SetActive(true);
            IsTextActiveBike = true;

        }

    }

    public void ShowBench()
    {
        bench.SetActive(!bench.activeSelf);

        if (IsTextActiveBench == true)
        {
            BenchText.GetComponent<Text>().text = "Learn from Character";
            lookleftbench.SetActive(false);
            IsTextActiveBench = false;
        }

        else if (IsTextActiveBench == false)
        {
            BenchText.GetComponent<Text>().text = "Hide Character";
            lookleftbench.SetActive(true);
            IsTextActiveBench = true;

        }
    }
}



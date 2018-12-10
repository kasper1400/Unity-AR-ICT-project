using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ZoomIntoObject : MonoBehaviour {

    public Camera ARCamera;
    public Camera ObjectCamera;

    public void ShowObjectCamera()
    {
        ARCamera.enabled = false;
        ObjectCamera.enabled = true;
    }

    //public void ShowFirstARCamera()
    //{
    //    ARCamera.enabled = true;
    //    ObjectCamera.enabled = false;
    //}

    // Use this for initialization
    void Start () {
		
	}
    // Update is called once per frame
    void Update () {
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ARController : MonoBehaviour {

    public GameObject InfoPopup;
    private bool IsAssitantActive;

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {
		
	}


    public void BackButton()
    {
        SceneManager.LoadScene("Menu");
    }

    public void CloseButton()
    {
        InfoPopup.SetActive(false);
    }

    public void InfoButton()
    {
        InfoPopup.SetActive(true);
    }
}

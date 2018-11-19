using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ARScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Info()
    {
        SceneManager.LoadScene("InfoScene");
    }

    public void ExitApp()
    {
        Application.Quit();
    }
}

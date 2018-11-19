using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(splashLoader());
    }

    IEnumerator splashLoader()
    {
        yield return new WaitForSeconds(4.5f);
        SceneManager.LoadScene("Menu");
    }

    // Update is called once per frame
    void Update () {
		
	}
}

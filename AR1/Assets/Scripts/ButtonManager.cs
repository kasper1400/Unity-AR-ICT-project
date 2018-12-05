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
 
    public void LukkariLink()
    {
        Application.OpenURL("https://lukkarit.hamk.fi/");
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void GoToYoutubeBench()
    {
        Application.OpenURL(" https://www.youtube.com/watch?v=tpLfsh2QB28&t=59s");
    }
    public void GotoYoutubeBike()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=Ovlm9wWTk7Y");
    }
    public void SendForm()
    {
        SceneManager.LoadScene("SendForm");
    }
    public void TicTacToe()
    {
        SceneManager.LoadScene("TicTacToeMain");
    }
   
}

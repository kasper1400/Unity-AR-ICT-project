using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmileyTapped : MonoBehaviour {
    public static bool rated = false;
	// Use this for initialization
	void Start () {
		
	}

    void sendRating(int rate)
    {
        Debug.Log("Aloitetaan taikalähetys");
        // Tarkista ettei ole jo arvosteltu
        if(!SmileyTapped.rated)
        {
            SmileyTapped.rated = true;
            var url = "http://arcticircuit.com/palvelimenphp.php";
            WWWForm form = new WWWForm();
            form.AddField("rating", rate);
            WWW www = new WWW(url, form);
            StartCoroutine(WaitForResponse(www));

        } else
        {
            //jo ravosteltu handleri tänne
        }
    }

    IEnumerator WaitForResponse(WWW www)
    {
        yield return www;

        if (www.error == null)
        {
            //oli virheetön toiminto, voi vaikka näyttää käyttäjälle kiitos arvostelusta
            Debug.Log(www.text);
        } else
        {
            // Oli virhe, voi vaikka ilmoittaa siitö käyttäjälle
            Debug.Log(www.error);
        }
    }

    public void one(){ sendRating(1); }
    public void two() { sendRating(2); }
    public void three() { sendRating(3); }
    public void four() { sendRating(4); }
    public void five() { sendRating(5); }
}

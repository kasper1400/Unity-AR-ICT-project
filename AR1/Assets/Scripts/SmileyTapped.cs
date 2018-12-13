using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SmileyTapped : MonoBehaviour 

{
    public static bool rated = false;

    public void sendRating(int rate)
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
    /*
    public void FirstBall(PointerEventData evd)
    {
        sendRating(1);
    }

    public void SecondBall(PointerEventData evd)
    {
        sendRating(2);
    }

    public void ThirdBall(PointerEventData evd)
    {
        sendRating(3);
    }

    public void FourthBall(PointerEventData evd)
    {
        sendRating(4);
    }

    public void FifthBall(PointerEventData evd)
    {
        sendRating(5);
    }

*/
    public void one()
    {
        sendRating(1);
    }
    public void two()
    {
        sendRating(2);
    }
    public void three()
    {
        sendRating(3);
    }
    public void four()
    {
        sendRating(4);
    }
    public void five()
    {
        sendRating(5);
    }
    
}

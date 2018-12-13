using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nappiskripti : MonoBehaviour {

    public SmileyTapped viitataan;
    public int arvosana;
    private void OnMouseDown()
    {
        viitataan.sendRating(arvosana);
    }
}

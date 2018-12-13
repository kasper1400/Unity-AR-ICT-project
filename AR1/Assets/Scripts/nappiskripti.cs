using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nappiskripti : MonoBehaviour {

    public GameObject GO;
    public SmileyTapped viitataan;
    public int arvosana;
    private void OnMouseDown()
    {
        viitataan.sendRating(arvosana);
        GO.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestVictory : MonoBehaviour {
    NumeroMagico oNumero;
    NumberReceptor thisNumberReceptor;

	void Start ()
    {
        oNumero = GameObject.FindGameObjectWithTag("Chave").GetComponent<NumeroMagico>();
        thisNumberReceptor = GetComponent<NumberReceptor>();
	}	

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (oNumero.valorMagico == thisNumberReceptor.thisNumber)
            {
                Debug.Log("YOU WON");
            }
        }
    }
}

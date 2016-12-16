using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueSorter : MonoBehaviour {

    public Vector2[] posicoesDeChegada = new Vector2[5];
    public Vector2[] posicoesDePartida = new Vector2[5];
    ValueMover a;
    int contadorDeBaixo = 0;

	void Start () {
		
	}
	
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "SOMEFUCKINGRANDOMTAG" && contadorDeBaixo < 5)
        {
            a = other.GetComponent<ValueMover>();
            a.posicaoDestino = posicoesDeChegada[contadorDeBaixo];
            posicoesDePartida[contadorDeBaixo] = a.thisTransform.position;
            a.startMoving = true;
            contadorDeBaixo++;
        }
        if(other.gameObject.tag == "RESETER")
        {
            contadorDeBaixo = 0;
        }
    }
}

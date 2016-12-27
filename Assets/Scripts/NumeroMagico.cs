using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumeroMagico : MonoBehaviour {
    public int valorAleatorio, valorMagico;
    TextMesh thisTextMesh;
    SequenciaManager a;

    void Start()
    {
        a = GameObject.FindGameObjectWithTag("Manager").GetComponent<SequenciaManager>();
        thisTextMesh = GetComponent<TextMesh>();
        valorAleatorio = Random.Range(0, a.numeroDeSequencias);
        valorMagico = a.NumeroAImprimir(valorAleatorio, a.numeroDeNumerosDasSequencias - 1);
        thisTextMesh.text = valorMagico.ToString();
    }
}

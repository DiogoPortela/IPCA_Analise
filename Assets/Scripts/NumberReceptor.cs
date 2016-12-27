using UnityEngine;
using System.Collections;

public class NumberReceptor : MonoBehaviour {

    public int sequence, number, thisNumber;
    public bool isOn = false;
    GameObject manager;
    TextMesh texto;
    MeshRenderer render;
    SequenciaManager a;

    void Start () {
        texto = GetComponent<TextMesh>();
        render = GetComponent<MeshRenderer>();
        render.enabled = isOn;
        manager = GameObject.FindGameObjectWithTag("Manager");
        a = manager.GetComponent<SequenciaManager>();
        thisNumber = a.NumeroAImprimir(sequence - 1, number - 1);
        texto.text = thisNumber.ToString();
    }

}

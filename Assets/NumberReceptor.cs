using UnityEngine;
using System.Collections;

public class NumberReceptor : MonoBehaviour {

    public int sequence, number;
    public bool isOn = false;
    GameObject manager;
    TextMesh texto;
    MeshRenderer render;
    OutcomeManager a;

    void Start () {
        texto = GetComponent<TextMesh>();
        render = GetComponent<MeshRenderer>();
        render.enabled = isOn;
        manager = GameObject.FindGameObjectWithTag("Manager");
        a = manager.GetComponent<OutcomeManager>();
        texto.text = a.NumeroAImprimir(sequence-1, number-1).ToString();
    }

}

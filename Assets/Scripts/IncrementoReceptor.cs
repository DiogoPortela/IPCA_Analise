using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncrementoReceptor : MonoBehaviour {
    public int IncrementoNo;
    TextMesh thisTextMesh;
    OutcomeManager a;

	void Start () {
        a = GameObject.FindGameObjectWithTag("Manager").GetComponent<OutcomeManager>();
        thisTextMesh = GetComponent<TextMesh>();
        thisTextMesh.text = a.IncrementoAImprimir(IncrementoNo - 1).ToString();
	}
}

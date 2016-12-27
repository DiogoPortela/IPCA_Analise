using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaPassaInformacao : MonoBehaviour {

    SequenciaManager SM;
    VitoriaManager VM;
    string valor;

	void Start () {
        SM = GameObject.Find("LevelManager").GetComponent<SequenciaManager>();
        VM = SM.gameObject.GetComponent<VitoriaManager>();
        valor = this.GetComponentInChildren<TextMesh>().text;
	}
	
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.name.Equals("Collider de Entrada"))
        {
            VM.receberNumero(this.gameObject);
            Destroy(this.gameObject);
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Pickup Target") && Input.GetKeyUp(KeyCode.E))
        {
            collision.GetComponentInParent<PlayerMovement>().receberObjecto(this.gameObject);
        }
    }
}

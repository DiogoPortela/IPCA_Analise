using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaPassaInformacao : MonoBehaviour {

    SequenciaManager SM;
    VitoriaManager VM;

	void Start () {
        SM = GameObject.Find("LevelManager").GetComponent<SequenciaManager>();
        VM = SM.gameObject.GetComponent<VitoriaManager>();
	}
	
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.name.Equals("Collider de Entrada"))
        {
            VM.receberNumero(this.gameObject);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.name.Equals("Pickup Target") && Input.GetKeyUp(KeyCode.E))
        {
            collision.GetComponentInParent<PlayerMovement>().receberObjecto(this.gameObject);
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

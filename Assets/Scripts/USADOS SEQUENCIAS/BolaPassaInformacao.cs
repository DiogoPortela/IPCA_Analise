using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaPassaInformacao : MonoBehaviour {

    SequenciaManager SM;
    string valor;

	void Start () {
        SM = GameObject.Find("LevelManager").GetComponent<SequenciaManager>();
        valor = this.GetComponentInChildren<TextMesh>().text;
	}
	
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.name.Equals("Collider de Entrada"))
        {
            
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Pickup Target") && Input.GetKeyDown(KeyCode.E))
        {
            collision.GetComponentInParent<PlayerMovement>().receberObjecto(this.gameObject);
        }
    }
}

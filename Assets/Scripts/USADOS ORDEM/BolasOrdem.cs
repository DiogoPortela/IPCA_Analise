using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolasOrdem : MonoBehaviour {

    OrdemManager OM;

	void Start ()
    {
		OM = GameObject.Find("LevelManager").GetComponent<OrdemManager>();
    }
	
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Collider de Entrada"))
        {
            OM.receberNumero(this.gameObject);
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

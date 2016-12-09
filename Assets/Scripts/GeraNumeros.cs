using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeraNumeros : MonoBehaviour {
    public int numeroDeNumeros;
    public GameObject text1, text2, text3, text4, text5;
    int[] numeros;


    void Awake ()
    {
        Random.InitState((int)Time.time);
        numeros = new int[numeroDeNumeros]; 
		for(int i = 0; i < numeroDeNumeros; i++)
        {
            numeros[i] = Random.Range(0, 100);
        }
        text1.GetComponent<TextMesh>().text = numeros[0].ToString();
        text2.GetComponent<TextMesh>().text = numeros[1].ToString();
        text3.GetComponent<TextMesh>().text = numeros[2].ToString();
        text4.GetComponent<TextMesh>().text = numeros[3].ToString();
        text5.GetComponent<TextMesh>().text = numeros[4].ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

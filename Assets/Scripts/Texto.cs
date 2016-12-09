using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Texto : MonoBehaviour {
    public Text Wintotal;
    public Text Botao;
    public int progresse;

	// Use this for initialization
	void Start () {
       Wintotal.text = " “ Sim... és tu? Sim...sim... ” - murmurou a bruxa";
       progresse=0;
        Botao.text = "Conta-me mais!";
}
	
	// Update is called once per frame
	void Update () {
        if (progresse == 1)
        {
            Wintotal.text = " “ Sim... és tu? Sim...sim... ” - murmurou a bruxa\n Ela entrega-te algo mestrioso";
        }
        if (progresse == 2)
        {
            Wintotal.text = " “ Sim... és tu? Sim...sim... ” - murmurou a bruxa\n Ela entrega-te algo mestrioso \n UM OVO DE DRAGÃO?";
        }
        if (progresse == 3)
        {
            Wintotal.text = " “ Sim... és tu? Sim...sim... ” - murmurou a bruxa\n Ela entrega-te algo mestrioso \n UM OVO DE DRAGÃO?\n “o Ovo racha, sai um bebé dragão, Ele parece gostar de ti!”";
        }
        if (progresse == 4)
        {
            Wintotal.text = "“A cada Dragão o Seu Heroi, a Cada Heroi a sua aventura, e esta é a tua...”";
            Botao.text = "Começar Aventura";
        }
        if (progresse == 5)
        {
            SceneManager.LoadScene("Level1");
        }
        if (Input.GetMouseButtonDown(0))
        {
            progresse++;
        }

    }    
}

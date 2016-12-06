using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1 : MonoBehaviour {
    public int valor11;
    public int valor12;
    public int valor21;
    public int valor22;
    public int EscolheSimbolo;
    public Text vstring11;
    public Text vstring12;
    public Text vstring21;
    public Text vstring22;
    public Text Simbolo;
    public double v11Por12;
    public double v21Por22;

    void Start () {
        //Gerar numeros aliatórios
        valor11 = Random.Range(1, 9);
        valor12 = Random.Range(1, 9);
        valor21 = Random.Range(1, 9);
        valor22 = Random.Range(1, 9);

        //Passar esses numeros para o UI
        vstring11.text = valor11.ToString();
        vstring12.text = valor12.ToString();
        vstring21.text = valor21.ToString();
        vstring22.text = valor22.ToString();

        //Dividir as frações
        v11Por12 = (double)valor11 / (double)valor12;
        v21Por22 = (double)valor21 / (double)valor22;

        //Atribuir simbolo e inicializar a variável EscolheSimbolo
        EscolheSimbolo = 0;
        Simbolo.text = ">";
    }

    // Update is called once per frame
    void Update() {

        //função para Tocar o Simbolo De acordo com o incremento
        if (EscolheSimbolo == 0) { Simbolo.text = ">"; }
        else if (EscolheSimbolo == 1) { Simbolo.text = "="; }
        else if (EscolheSimbolo == 2) { Simbolo.text = "<"; }
        //função para retornar o valor do EscolheSimbolo
        else EscolheSimbolo = 0;
    }
    

    //Colisão player para trocar
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Trocar")
        {
            EscolheSimbolo = EscolheSimbolo + 1;
        }
        //Colisão player para Ganhar
        if (other.gameObject.tag == "Testar")
        {
            if(EscolheSimbolo==1 && v11Por12 == v21Por22) { Debug.Log("Win1"); }
            else if (EscolheSimbolo == 0 && v11Por12 > v21Por22) { Debug.Log("Win2"); }
            else if (EscolheSimbolo == 2 && v11Por12 < v21Por22) { Debug.Log("Win3"); }
            else Debug.Log("LOSE");
        }
    }
} 
   



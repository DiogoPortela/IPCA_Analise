using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level1 : MonoBehaviour {
    public int valor11;
    public int valor12;
    public int valor21;
    public int valor22;
    public int EscolheSimbolo;
    public int padraoJogo; //Escolhe como será apresentada a fracao
    public int insidepadrao; //escolhe qual a fracao que sera maior
    public int multi; //valor fixo que multiplica
    public Text vstring11;
    public Text vstring12;
    public Text vstring21;
    public Text vstring22;
    public Text Simbolo;
    public double v11Por12;
    public double v21Por22;

    void Start () {

        Random.InitState(System.DateTime.Now.Millisecond); 
        padraoJogo = Random.Range(1, 4);
        insidepadrao = Random.Range(1, 2);
        if (padraoJogo == 1)
        {
            valor11 = Random.Range(1, 9);
            valor12 = Random.Range(1, 9);
            valor21 = valor11;
            valor22 = Random.Range(1, 9);

        }
        else if(padraoJogo == 2)
        {
            valor11 = Random.Range(1, 9);
            valor12 = Random.Range(1, 9);
            valor21 = Random.Range(1, 9);
            valor22 = valor12;

        }
        else
        {
            if (insidepadrao == 1)
            {
                multi = Random.Range(1, 5);
                valor11 = Random.Range(1, 9);
                valor12 = Random.Range(1, 9);
                valor21 = multi*valor11;
                valor22 = multi*valor12;
            }
            else
            {
                multi = Random.Range(1, 5);
                valor21 = Random.Range(1, 9);
                valor22 = Random.Range(1, 9);
                valor11 = multi * valor21;
                valor12 = multi * valor22;               
            }
         }
   

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
        if (other.gameObject.tag == "Maior")
        {
            EscolheSimbolo = 2;
        }
        else if (other.gameObject.tag == "Igual")
        {
            EscolheSimbolo = 1;
        }
       else if (other.gameObject.tag == "Menor")
        {
            EscolheSimbolo = 0;
        }
        //Colisão player para Ganhar
        if (other.gameObject.tag == "Maior"|| other.gameObject.tag == "Igual"|| other.gameObject.tag == "Menor")
        {
            if(EscolheSimbolo==1 && v11Por12 == v21Por22) {SceneManager.LoadScene("Level2") ; }
            else if (EscolheSimbolo == 0 && v11Por12 > v21Por22) { SceneManager.LoadScene("Level2"); }
            else if (EscolheSimbolo == 2 && v11Por12 < v21Por22) { SceneManager.LoadScene("Level2"); }
            else Debug.Log("LOSE");
        }
    }
} 
   



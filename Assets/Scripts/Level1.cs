using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    public int wins;
    public GameObject vstring11;
    public GameObject vstring12;
    public GameObject vstring21;
    public GameObject vstring22;
    public GameObject Simbolo;
    public double v11Por12;
    public double v21Por22;
    public GameObject visto1;
    public GameObject visto2;
    public GameObject visto3;
    public GameObject Porta;
    public void Comeco() {
       
        visto1.GetComponent<Renderer>().enabled = false;
        visto2.GetComponent<Renderer>().enabled = false;
        visto3.GetComponent<Renderer>().enabled = false;

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
        else if (padraoJogo == 2)
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
                valor21 = multi * valor11;
                valor22 = multi * valor12;
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
        vstring11.GetComponent<TextMesh>().text = valor11.ToString();
        vstring12.GetComponent<TextMesh>().text = valor12.ToString();
        vstring21.GetComponent<TextMesh>().text = valor21.ToString();
        vstring22.GetComponent<TextMesh>().text = valor22.ToString();

        //Dividir as frações
        v11Por12 = (double)valor11 / (double)valor12;
        v21Por22 = (double)valor21 / (double)valor22;

        //Atribuir simbolo e inicializar a variável EscolheSimbolo
        //EscolheSimbolo = 1;
        //Simbolo.GetComponent<TextMesh>().text = "=";
    }
    void Start () {
        wins = 0;
        Comeco();
    }

    // Update is called once per frame
    void Update() {

        //função para Tocar o Simbolo De acordo com o incremento
        if (EscolheSimbolo == 0) { Simbolo.GetComponent<TextMesh>().text = "<"; }
        else if (EscolheSimbolo == 1) { Simbolo.GetComponent<TextMesh>().text = "="; }
        else if (EscolheSimbolo == 2) { Simbolo.GetComponent<TextMesh>().text = ">"; }
        //função para retornar o valor do EscolheSimbolo

        if (wins == 1)
        {
            visto1.GetComponent<Renderer>().enabled = true;
        }
        else if (wins == 2)
        {
            visto1.GetComponent<Renderer>().enabled = true;
            visto2.GetComponent<Renderer>().enabled = true;
        }
        else if (wins == 3)
        {          
            visto1.GetComponent<Renderer>().enabled = true;
            visto2.GetComponent<Renderer>().enabled = true;
            visto3.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            if (wins > 3) wins = 3;
            else wins = 0;
        }
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
            if (EscolheSimbolo == 1 && v11Por12 == v21Por22) { wins++; Comeco(); }
            else if (EscolheSimbolo == 0 && v11Por12 < v21Por22) { wins++;Comeco(); }
            else if (EscolheSimbolo == 2 && v11Por12 > v21Por22) { wins++; Comeco(); }
        }
        if (wins == 3)
        {
            vstring11.GetComponent<Renderer>().enabled = false;
            vstring12.GetComponent<Renderer>().enabled = false;
            vstring21.GetComponent<Renderer>().enabled = false;
            vstring22.GetComponent<Renderer>().enabled = false;
            Simbolo.GetComponent<Renderer>().enabled = false;
            Porta.GetComponent<MudarNivel>().Vitoria = true;
        }
    }
} 
   



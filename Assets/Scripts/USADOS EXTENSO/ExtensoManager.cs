using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExtensoManager : MonoBehaviour {
    public int DMilhares, Milhares, Centenas, Dezenas, Unidades, Finalnumber, RandomCerta;
    public GameObject Resposta1, Resposta2, Resposta3, Resposta4;
    public GameObject visto1, visto2, visto3, Porta;
    public GameObject Questao;

    int wins, antiga;

    string SDMilhares;
    string SMilhares;
    string SCentenas;
    string SDezenas;
    string SUnidades;

    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        wins = 0;
        comeco();
    }

    public void atribuicomeco()
    {
        RandomCerta = Random.Range(1, 5);
        if (RandomCerta == 1 && antiga != 1)
        {
            //Resposta1.text = Finalnumber.ToString();
            Resposta1.GetComponent<TextMesh>().text = Finalnumber.ToString();
            Resposta2.GetComponent<TextMesh>().text = Random.Range(10000, 99999).ToString();
            Resposta3.GetComponent<TextMesh>().text = Random.Range(10000, 99999).ToString();
            Resposta4.GetComponent<TextMesh>().text = Random.Range(10000, 99999).ToString();
        }
        else if (RandomCerta == 2 && antiga != 2)
        {
            Resposta1.GetComponent<TextMesh>().text = Random.Range(10000, 99999).ToString();
            Resposta2.GetComponent<TextMesh>().text = Finalnumber.ToString();
            Resposta3.GetComponent<TextMesh>().text = Random.Range(10000, 99999).ToString();
            Resposta4.GetComponent<TextMesh>().text = Random.Range(10000, 99999).ToString();
        }
        else if (RandomCerta == 3 && antiga != 3)
        {
            Resposta1.GetComponent<TextMesh>().text = Random.Range(10000, 99999).ToString();
            Resposta2.GetComponent<TextMesh>().text = Random.Range(10000, 99999).ToString();
            Resposta3.GetComponent<TextMesh>().text = Finalnumber.ToString();
            Resposta4.GetComponent<TextMesh>().text = Random.Range(10000, 99999).ToString();
        }
        else if (RandomCerta == 4 || RandomCerta == 5) { 
            if (antiga != 4 || antiga != 5)
            {
                atribuicomeco();
            }
            else
            
                {
                    Resposta1.GetComponent<TextMesh>().text = Random.Range(10000, 99999).ToString();
                    Resposta2.GetComponent<TextMesh>().text = Random.Range(10000, 99999).ToString();
                    Resposta3.GetComponent<TextMesh>().text = Random.Range(10000, 99999).ToString();
                    Resposta4.GetComponent<TextMesh>().text = Finalnumber.ToString();
                }
            }
        else { atribuicomeco(); }
    }
    public void comeco()
    {
        //Cria o número
        DMilhares = (int)Random.Range(2, 9) * 10000;
        Milhares = (int)Random.Range(1, 9) * 1000;
        Centenas = (int)Random.Range(1, 9) * 100;
        Dezenas = (int)Random.Range(2, 9) * 10;
        Unidades = (int)Random.Range(1, 9);
        Finalnumber = DMilhares + Milhares + Centenas + Dezenas + Unidades;

        //atribui a certa
        atribuicomeco();

        switch (DMilhares)
        {
            case 20000:
                SDMilhares = "Vinte e ";
                break;
            case 30000:
                SDMilhares = "Trinta e ";
                break;
            case 40000:
                SDMilhares = "Quarenta e ";
                break;
            case 50000:
                SDMilhares = "Cinquenta e ";
                break;
            case 60000:
                SDMilhares = "Sessenta e ";
                break;
            case 70000:
                SDMilhares = "Setenta e ";
                break;
            case 80000:
                SDMilhares = "Oitenta e ";
                break;
            case 90000:
                SDMilhares = "Noventa e ";
                break;
            default:
                break;
        }

        switch (Milhares)
        {
            case 1000:
                SMilhares = "Um mil ";
                break;
            case 2000:
                SMilhares = "Dois mil ";
                break;
            case 3000:
                SMilhares = "Tres mil ";
                break;
            case 4000:
                SMilhares = "Quatro mil ";
                break;
            case 5000:
                SMilhares = "Cinco mil ";
                break;
            case 6000:
                SMilhares = "Seis mil ";
                break;
            case 7000:
                SMilhares = "Sete mil ";
                break;
            case 8000:
                SMilhares = "Oito mil ";
                break;
            case 9000:
                SMilhares = "Nove mil ";
                break;
            default:
                break;
        }

        switch (Centenas)
        {
            case 100:
                SCentenas = "Cento e ";
                break;
            case 200:
                SCentenas = "Duzentos e ";
                break;
            case 300:
                SCentenas = "Trezentos e ";
                break;
            case 400:
                SCentenas = "Quatrocentos e ";
                break;
            case 500:
                SCentenas = "Quinhentos e ";
                break;
            case 600:
                SCentenas = "Seiscentos e ";
                break;
            case 700:
                SCentenas = "Setecentos e ";
                break;
            case 800:
                SCentenas = "Oitocentos e ";
                break;
            case 900:
                SCentenas = "Novecentos e";
                break;
            default:
                break;
        }


        switch (Dezenas)
        {
            case 20:
                SDezenas = "Vinte e ";
                break;
            case 30:
                SDezenas = "Trinta e ";
                break;
            case 40:
                SDezenas = "Quarenta e ";
                break;
            case 50:
                SDezenas = "Cinquenta e ";
                break;
            case 60:
                SDezenas = "Sessenta e ";
                break;
            case 70:
                SDezenas = "Setenta e ";
                break;
            case 80:
                SDezenas = "Oitenta e ";
                break;
            case 90:
                SDezenas = "Noventa e";
                break;
            default:
                break;
        }

        switch (Unidades)
        {
            case 1:
                SUnidades = "Um";
                break;
            case 2:
                SUnidades = "Dois";
                break;
            case 3:
                SUnidades = "Tres";
                break;
            case 4:
                SUnidades = "Quatro";
                break;
            case 5:
                SUnidades = "Cinco";
                break;
            case 6:
                SUnidades = "Seis";
                break;
            case 7:
                SUnidades = "Sete";
                break;
            case 8:
                SUnidades = "Oito";
                break;
            case 9:
                SUnidades = "Nove";
                break;
            default:
                break;
        }

        Questao.GetComponent<TextMesh>().text = SDMilhares + SMilhares + SCentenas + SDezenas + SUnidades;    
   }
	
	void Update () {
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Resposta1" && RandomCerta == 1)
        {
            wins++;
            antiga = 1;
            comeco();
        }
        else if (other.gameObject.tag == "Resposta2" && RandomCerta == 2)
        {
            wins++;
            antiga = 2;
            comeco();
        }
        else if (other.gameObject.tag == "Resposta3" && RandomCerta == 3)
        {
            wins++;
            antiga = 3;
            comeco();
        }
        else if ((other.gameObject.tag == "Resposta4" && RandomCerta == 4) || (other.gameObject.tag == "Resposta4" && RandomCerta == 5))
        {
            wins++;
            antiga = 4;
            comeco();
        }

        if (wins == 3)
        {
            Resposta1.GetComponent<Renderer>().enabled = false; 
            Resposta2.GetComponent<Renderer>().enabled = false; 
            Resposta3.GetComponent<Renderer>().enabled = false; 
            Resposta4.GetComponent<Renderer>().enabled = false; 
            Questao.GetComponent<Renderer>().enabled = false;
            Porta.GetComponent<MudarNivel>().Vitoria = true;
        }

    }
    }

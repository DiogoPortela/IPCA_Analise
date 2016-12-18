using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level5function : MonoBehaviour {
    public int DMilhares;
    public int Milhares;
    public int Centenas;
    public int Dezenas;
    public int Unidades;
    public int Finalnumber;
    public int RandomCerta;

    public Text Resposta1;
    public Text Resposta2;
    public Text Resposta3;
    public Text Resposta4;

    public Text Questao;
    string SDMilhares;
    string SMilhares;
    string SCentenas;
    string SDezenas;
    string SUnidades;
    void Start () {
            //Cria o número
        Random.InitState(System.DateTime.Now.Millisecond);
        DMilhares =(int)Random.Range(2, 9) * 10000;
        Milhares = (int)Random.Range(1, 9) * 1000;
        Centenas= (int)Random.Range(1, 9) * 100;
        Dezenas= (int)Random.Range(2, 9) * 10;
        Unidades= (int)Random.Range(1, 9);
        Finalnumber = DMilhares + Milhares + Centenas + Dezenas + Unidades;

        //atribui a certa
        RandomCerta = Random.Range(1, 5);
        if(RandomCerta == 1) { 
            Resposta1.text = Finalnumber.ToString();
            Resposta2.text = Random.Range(10000, 99999).ToString();
            Resposta3.text = Random.Range(10000, 99999).ToString();
            Resposta4.text = Random.Range(10000, 99999).ToString();
        }
        else if(RandomCerta == 2) {
            Resposta1.text = Random.Range(10000, 99999).ToString();
            Resposta2.text = Finalnumber.ToString();
            Resposta3.text = Random.Range(10000, 99999).ToString();
            Resposta4.text = Random.Range(10000, 99999).ToString();
        }
        else if (RandomCerta == 3)
        {
            Resposta1.text = Random.Range(10000, 99999).ToString();
            Resposta2.text = Random.Range(10000, 99999).ToString();
            Resposta3.text = Finalnumber.ToString();
            Resposta4.text = Random.Range(10000, 99999).ToString();
        }
        else
        {
            Resposta1.text = Random.Range(10000, 99999).ToString();
            Resposta2.text = Random.Range(10000, 99999).ToString();
            Resposta3.text = Random.Range(10000, 99999).ToString();
            Resposta4.text = Finalnumber.ToString();
        }

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

        Questao.text = SDMilhares+SMilhares+SCentenas+SDezenas+SUnidades;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

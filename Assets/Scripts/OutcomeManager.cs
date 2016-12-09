using UnityEngine;
using System.Collections;

public class Sequencia
{
    private int[] numerosDaSequencia;
    private int primeiroValor;
    private int incremento;

    public int[] NumerosDaSequencia
    {
        get { return numerosDaSequencia; }
        set { numerosDaSequencia = value; }
    }
    public int PrimeiroValor
    {
        get { return primeiroValor; }
        set { primeiroValor = value; }
    }
    public int Incremento
    {
        get { return incremento; }
        set { incremento = value; }
    }


    public Sequencia(int n, int numero, int incremento)
    {
        this.numerosDaSequencia = new int[n];
        this.primeiroValor = numero;
        this.incremento = incremento;
    }


}

public class OutcomeManager : MonoBehaviour {

    int teste;

    public int[] numerosInicias;
    public int[] incrementos;
    public int numeroDeSequencias = 2, numeroDeNumerosDasSequencias = 5;
    public Sequencia[] sequencias;


    int primeiro, incremento;


	void Awake () {
        sequencias = new Sequencia[numeroDeSequencias];
        Random.InitState((int)Time.time);

        for(int i = 0; i < numeroDeSequencias; i++)
        {
            primeiro = numerosInicias[Random.Range(0, numerosInicias.Length)];
            incremento = incrementos[Random.Range(0, incrementos.Length)];

            for (int o = 0; o < i; o++)
            {
                if (primeiro == sequencias[o].PrimeiroValor && incremento == sequencias[o].Incremento)
                {
                    primeiro = numerosInicias[Random.Range(0, numerosInicias.Length)];
                     incremento = incrementos[Random.Range(0, incrementos.Length)];
                }
            }

            sequencias[i] = new Sequencia(numeroDeNumerosDasSequencias, primeiro, incremento);
            Debug.Log("Sequencia: " + i + " Primeiro: " + primeiro + " Incremento: " + incremento);
            for (int n = 0; n < numeroDeNumerosDasSequencias; n ++)
            {
                sequencias[i].NumerosDaSequencia[n] = primeiro + incremento * n;
                //Debug.Log(sequencias[i].NumerosDaSequencia[n]); 
            }           
        }                       
	}

   public int NumeroAImprimir(int s, int n)
    {
        return sequencias[s].NumerosDaSequencia[n];
    }

    public int IncrementoAImprimir(int s)
    {
        return sequencias[s].Incremento;
    }
}

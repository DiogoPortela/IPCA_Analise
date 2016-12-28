using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sequencia
{
    /*private int[] numerosDaSequencia;//OBSOLETO
    public int[] NumerosDaSequencia //OBSOLETO
  {
      get { return numerosDaSequencia; }
      set { numerosDaSequencia = value; }
  }
     public Sequencia(int n, int incremento) //OBSOLETO
  {
         this.numerosDaSequencia = new int[n];
         this.incremento = incremento;
         this.listaNumerosSequencia = new List<int>();
  }*/
    private int incremento;
    private List<int> listaNumerosSequencia;


    public int Incremento
    {
        get { return incremento; }
        set { incremento = value; }
    }
    public List<int> ListaNumerosSequencia
    {
        get { return listaNumerosSequencia; }
        set { listaNumerosSequencia = value; }
    }

    public Sequencia(int incremento)
    {
        this.incremento = incremento;
        this.listaNumerosSequencia = new List<int>();
    }


}

public class SequenciaManager : MonoBehaviour
{

    public int[] numerosInicias;
    public int[] incrementos;
    public int numeroDeSequencias = 2, numeroDeNumerosDasSequencias = 5;
    public List<Sequencia> sequenciasArray;


    int primeiro, incremento;


    void Awake()
    {
        sequenciasArray = new List<Sequencia>();
        Random.InitState((int)System.DateTime.Now.Ticks);

        for (int i = 0; i < numeroDeSequencias; i++)
        {
            primeiro = numerosInicias[Random.Range(0, numerosInicias.Length)];
            incremento = incrementos[Random.Range(0, incrementos.Length)];

            for (int o = 0; o < i; o++)
            {
                if (primeiro == sequenciasArray[o].ListaNumerosSequencia[0] && incremento == sequenciasArray[o].Incremento)
                {
                    primeiro = numerosInicias[Random.Range(0, numerosInicias.Length)];
                    incremento = incrementos[Random.Range(0, incrementos.Length)];
                }
            }

            sequenciasArray.Add(new Sequencia(incremento));
            Debug.Log("Sequencia: " + i + " Primeiro: " + primeiro + " Incremento: " + incremento);
            for (int n = 0; n < numeroDeNumerosDasSequencias; n++)
            {
                sequenciasArray[i].ListaNumerosSequencia.Add(primeiro + incremento * n);
            }
        }
    }

    public int NumeroAImprimir(int s, int n)
    {
        return sequenciasArray[s].ListaNumerosSequencia[n];
    }
    public int IncrementoAImprimir(int s)
    {
        return sequenciasArray[s].Incremento;
    }
}

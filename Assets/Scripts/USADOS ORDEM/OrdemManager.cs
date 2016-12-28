using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrdemManager : MonoBehaviour {

    public GameObject spawn1, spawn2, spawn3, porta, bolasParent, bolaPrefab, bolaGrandePrefab;
    public GameObject check1, check2, check3;
    public int numeroMaximo;
    public int numeroMinimo;
    public int quantidadeNumeros = 5;

    int[] numerosOrdenados, numerosIntroduzidos;
    int ultimoNumeroGerado = 0, numeroNumerosIntroduzidos = 0, victoria = 0;
    List<GameObject> auxBolas = new List<GameObject>();
    List<GameObject> auxBolasGrandes = new List<GameObject>();

    void Awake ()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
        check1.SetActive(false);
        check2.SetActive(false);
        check3.SetActive(false);
        numerosOrdenados = new int[quantidadeNumeros];
        numerosIntroduzidos = new int[quantidadeNumeros];
        geraOrdem();        
    }

    public void receberNumero(GameObject obj)
    {
        numeroNumerosIntroduzidos++;
        auxBolasGrandes.Add(Instantiate(bolaGrandePrefab, spawn3.transform.position, new Quaternion(), bolasParent.transform));
        auxBolasGrandes[auxBolasGrandes.Count - 1].gameObject.GetComponentInChildren<TextMesh>().text = obj.GetComponentInChildren<TextMesh>().text;
        numerosIntroduzidos[numeroNumerosIntroduzidos - 1] = int.Parse(obj.GetComponentInChildren<TextMesh>().text);

        if(numeroNumerosIntroduzidos == quantidadeNumeros)
        {
            StartCoroutine(ifVictory());
        }
        else if(numeroNumerosIntroduzidos > quantidadeNumeros)
        {
            Debug.LogError("SOMETHING WENT TERRIBLY WRONG: MAIS NUMEROS INTRODUZIDOS DO QUE O PERMITIDO");
        }

    }

    private void geraOrdem()
    {
        foreach (GameObject o in auxBolas)
        {
            Destroy(o);
        }
        foreach (GameObject o in auxBolasGrandes)
        {
            Destroy(o);
        }
        auxBolas.Clear();
        auxBolasGrandes.Clear();

        ultimoNumeroGerado = Random.Range(numeroMinimo, (numeroMaximo / quantidadeNumeros));
        numerosOrdenados[0] = ultimoNumeroGerado;
        Debug.Log(ultimoNumeroGerado);

        for (int i = 1; i < quantidadeNumeros; i++)
        {
            int auxInt = ultimoNumeroGerado;           
            do
            {
                ultimoNumeroGerado = Random.Range(ultimoNumeroGerado, ((numeroMaximo * (i + 1)) / quantidadeNumeros));

            } while (auxInt == ultimoNumeroGerado);
            numerosOrdenados[i] = ultimoNumeroGerado;
            Debug.Log(ultimoNumeroGerado);
        }

        System.Array.Reverse(numerosOrdenados);

        StartCoroutine(SpawnBalls());
    }

    IEnumerator ifVictory()
    {
        int i = 0, j = 0;
        foreach (int num in numerosIntroduzidos)
        {
            if (num == numerosOrdenados[i])
            {
                j++;
            }
            i++;

        }
        if (i == j)
        {
            victoria++;
            switch (victoria)
            {
                case 1:
                    check1.SetActive(true);
                    break;
                case 2:
                    check2.SetActive(true);
                    break;
                case 3:
                    check3.SetActive(true);
                    porta.GetComponent<MudarNivel>().Vitoria = true;
                    break;
                default:
                    break;
            }
        }
        yield return new WaitForSecondsRealtime(7f);
        numeroNumerosIntroduzidos = 0;
        geraOrdem();
    }
    IEnumerator SpawnBalls()
    {
        List<string> auxString = new List<string>();

        for(int i = 0; i < quantidadeNumeros; i++)
        {
            auxString.Add(numerosOrdenados[i].ToString());
        }

        for (int i = 0; i < auxString.Count; i++)
        {
            string temp = auxString[i];
            int randomIndex = Random.Range(i, auxString.Count);
            auxString[i] = auxString[randomIndex];
            auxString[randomIndex] = temp;
        }


        for (int i = 0; i < quantidadeNumeros; i++)
        {
            if (i % 2 == 0)
            {
                auxBolas.Add(Instantiate(bolaPrefab, spawn1.transform.position, new Quaternion(), bolasParent.transform));
            }
            else
            {
                auxBolas.Add(Instantiate(bolaPrefab, spawn2.transform.position, new Quaternion(), bolasParent.transform));
            }
            auxBolas[auxBolas.Count - 1].GetComponentInChildren<TextMesh>().text = auxString[i];
            yield return new WaitForSecondsRealtime(1f);
        }
        auxString.Clear();
    }
}

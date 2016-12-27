using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VitoriaManager : MonoBehaviour
{
    public GameObject check1, check2, check3, incremento;
    public GameObject valorSequencia1, valorSequencia2, valorSequencia3, valorSequencia4, valorSequencia5;
    public GameObject bolaPrefab, spawnPoint1, spawnPoint2, bolasParent;
    public int numeroDeBolas = 6;
    public Color laranjaTexto, azulTexto;

    SequenciaManager SM;
    Sequencia randomSequencia, sequenciaPosta;
    List<GameObject> listaBolas;
    bool largarNumeros = true, stopBlink = false;

    void Start()
    {
        Random.InitState((int)Time.time);
        check1.SetActive(false);
        check2.SetActive(false);
        check3.SetActive(false);
        SM = this.gameObject.GetComponent<SequenciaManager>();
        randomSequencia = SM.sequenciasArray[Random.Range(0, SM.numeroDeNumerosDasSequencias)];
        Debug.Log("Sequencia escolhida: " + randomSequencia.ListaNumerosSequencia[0] + " , " + randomSequencia.Incremento);

        sequenciaPosta = new Sequencia(0);
        listaBolas = new List<GameObject>();

        incremento.GetComponent<TextMesh>().text = "-";
        valorSequencia1.GetComponent<TextMesh>().text = "-";
        valorSequencia2.GetComponent<TextMesh>().text = "-";
        valorSequencia3.GetComponent<TextMesh>().text = "-";
        valorSequencia4.GetComponent<TextMesh>().text = "-";
        valorSequencia5.GetComponent<TextMesh>().text = randomSequencia.ListaNumerosSequencia[4].ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (sequenciaPosta.ListaNumerosSequencia.Count == SM.numeroDeNumerosDasSequencias)
        {
            Debug.Log("FULL");
            largarNumeros = true;
        }
        if (largarNumeros)
        {
            largarNumeros = false;
            listaBolas.Clear();
            StartCoroutine(Blink(valorSequencia1));
            StartCoroutine(SpawnBalls());

        }
    }
    IEnumerator SpawnBalls()
    {
        List<string> aux = new List<string>();

        aux.Add(randomSequencia.ListaNumerosSequencia[0].ToString());
        aux.Add(randomSequencia.Incremento.ToString());
        for (int i = 0; i < numeroDeBolas - 2; i += 2)
        {
            string aux1, aux2;
            aux1 = SM.numerosInicias[Random.Range(0, SM.numerosInicias.Length)].ToString();
            aux2 = SM.incrementos[Random.Range(0, SM.incrementos.Length)].ToString();

            aux.Add(aux1);
            aux.Add(aux2);
        }

        for (int i = 0; i < aux.Count; i++)
        {
            string temp = aux[i];
            int randomIndex = Random.Range(i, aux.Count);
            aux[i] = aux[randomIndex];
            aux[randomIndex] = temp;
        }


        for (int i = 0; i < numeroDeBolas; i++)
        {
            if (i % 2 == 0)
            {
                listaBolas.Add(Instantiate(bolaPrefab, spawnPoint1.transform.position, new Quaternion(), bolasParent.transform));
            }
            else
            {
                listaBolas.Add(Instantiate(bolaPrefab, spawnPoint2.transform.position, new Quaternion(), bolasParent.transform));
            }
            listaBolas[listaBolas.Count-1].GetComponentInChildren<TextMesh>().text = aux[i];
            yield return new WaitForSecondsRealtime(1f);
        }
    }
    IEnumerator Blink(GameObject texto)
    {
        while (true)
        {
            texto.GetComponent<TextMesh>().color = laranjaTexto;
            yield return new WaitForSecondsRealtime(0.5f);
            texto.GetComponent<TextMesh>().color = azulTexto;
            yield return new WaitForSecondsRealtime(0.5f);
            if (stopBlink)
                break;
        }
    }
}

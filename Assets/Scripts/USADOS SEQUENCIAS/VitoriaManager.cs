﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VitoriaManager : MonoBehaviour
{
    public GameObject check1, check2, check3, incremento;
    public GameObject valorSequencia1, valorSequencia2, valorSequencia3, valorSequencia4, valorSequencia5;
    public GameObject bolaPrefab, spawnPoint1, spawnPoint2, bolasParent;
    public int numeroDeBolas = 6;

    SequenciaManager SM;
    Sequencia randomSequencia, sequenciaPosta;
    bool largarNumeros = true;

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
        if(sequenciaPosta.ListaNumerosSequencia.Count == SM.numeroDeNumerosDasSequencias)
        {
            Debug.Log("FULL");
            largarNumeros = true;
        }
        if(largarNumeros)
        {
            largarNumeros = false;
            StartCoroutine(SpawnBalls());
            
        }
    }
    IEnumerator SpawnBalls()
    {
        for (int i = 0; i < numeroDeBolas; i++)
        {            
            if (i % 2 == 0)
            {
                Instantiate(bolaPrefab, spawnPoint1.transform.position, new Quaternion(), bolasParent.transform);
                Debug.Log("spawned on 1");
            }
            else
            {
                Instantiate(bolaPrefab, spawnPoint2.transform.position, new Quaternion(), bolasParent.transform);
                Debug.Log("spawned on 2");
            }
            yield return new WaitForSecondsRealtime(1f);
        }
    }
}

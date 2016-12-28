using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MudarNivel : MonoBehaviour
{
    private bool vitoria;
    public bool Vitoria
    {
        get { return vitoria; }
        set { vitoria = value; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player") && (Input.GetKeyDown(KeyCode.E)) && vitoria)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player") && (Input.GetKeyDown(KeyCode.E)) && vitoria)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}

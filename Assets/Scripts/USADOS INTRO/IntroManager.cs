using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public string[] text;
    public TextMesh target;

    int counter = 0;

    public void next()
    {
        counter++;
        if(counter < text.Length + 1)
        {
            target.text += "\n" + text[counter - 1];
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

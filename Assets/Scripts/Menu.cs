using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("space_shooter");
    }


    public void Quit()
    {
        Debug.Log("SAIU");
        Application.Quit();
    }
}


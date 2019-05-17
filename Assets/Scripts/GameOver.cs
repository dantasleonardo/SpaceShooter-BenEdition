using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void PlayAgain()
    {
        GameController.Score = 0;
        SceneManager.LoadScene("Menu");
    }


    public void Quit()
    {
        Debug.Log("SAIU");
        Application.Quit();
    }
}

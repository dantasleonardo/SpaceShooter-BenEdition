﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static int Score;

    public string ScorePrefix = string.Empty;

    public Text ScoreText = null;

    public Text GameOverText = null;

    public GameObject powerUp;

    public static GameController ThisInstance = null;
    // Start is called before the first frame update
    void Awake()
    {
        ThisInstance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreText != null)
        {
            ScoreText.text = ScorePrefix + Score.ToString();
        }

        //Invoke("AparecePowerUp", 5);

    }

    /*public void AparecePowerUp()
    {
        powerUp.SetActive(true);
    }*/

    public static void GameOver()
    {
        if (ThisInstance.GameOverText != null)
            ThisInstance.GameOverText.gameObject.SetActive(true);
    }
}

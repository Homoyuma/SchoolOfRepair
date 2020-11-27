﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject completeLevelUI;
    private bool gameEnded;

    private void Start()
    {
        gameEnded = false;
    }
    void Update()
    {
        if (gameEnded)
            return;

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }
    void EndGame()
    {
        gameEnded = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        gameEnded = true;
        completeLevelUI.SetActive(true);
    }
}

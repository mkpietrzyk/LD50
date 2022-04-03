using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityAtoms.BaseAtoms;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public BoolVariable gameStarted;
    public BoolVariable gamePaused;
    public BoolVariable gameEnded;
    public StringVariable uiState;
    public TMP_InputField playerInput;
    public IntVariable misses;
    public IntVariable score;

    private void Start()
    {
        uiState.Value = uiState.InitialValue;
        playerInput.DeactivateInputField();
    }

    private void Update()
    {
        if (gameStarted.Value && Input.GetKeyDown(KeyCode.Escape))
        {
            gamePaused.Value = !gamePaused.Value;
            if (gamePaused.Value)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    public void StartGame()
    {
        gameStarted.Value = true;
        uiState.Value = "PlayerUI";
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        uiState.Value = "PauseMenu";
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        uiState.Value = "PlayerUI";
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ReturnToMenu()
    {
        gameStarted.Value = false;
        gamePaused.Value = false;
        gameEnded.Value = false;
        uiState.Value = "MainMenu";
    }

    public void EndGame()
    {
        gameStarted.Value = false;
        gamePaused.Value = false;
        gameEnded.Value = true;
        misses.Value = 0;
        score.Value = 0;
        Time.timeScale = 0;
        uiState.Value = "Ending";
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void CheckMisses(int misses)
    {
        if (misses >= 3)
        {
            EndGame();
        }
    }
}
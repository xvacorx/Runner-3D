using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject inGameUI;

    private void Start()
    {
        mainMenu.SetActive(true);
        gameOver.SetActive(false);
        inGameUI.SetActive(false);
    }

    public void MainMenu()
    {
        mainMenu.SetActive(true);
        gameOver.SetActive(false);
        inGameUI.SetActive(false);
    }
    public void GameOverScreen()
    {
        mainMenu.SetActive(false);
        gameOver.SetActive(true);
        inGameUI.SetActive(false);
    }
    public void InGameUI()
    {
        mainMenu.SetActive(false);
        gameOver.SetActive(false);
        inGameUI.SetActive(true);
    }
}

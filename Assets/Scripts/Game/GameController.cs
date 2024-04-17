using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameController : MonoBehaviour
{
    [SerializeField] ParallaxController parallaxController;
    [SerializeField] RandomSpawner spawner;
    [SerializeField] MenuManager menu;
    [SerializeField] UIController visualControler;
    [SerializeField] PlayerManager player;
    private void Start()
    {
        parallaxController.ToggleActive(false);
        visualControler.scoreActive = true;
        menu.MainMenu();
        spawner.StopInvoke();
    }
    public void StartGame()
    {
        player.Restart();
        Debug.Log("Game started");
        parallaxController.ToggleActive(true);
        menu.InGameUI();
        visualControler.scoreActive = true;
        visualControler.score = 0;
        spawner.StartInvoke();
        spawner.spawnInterval = 5;
    }
    public void GameOver()
    {
        Debug.Log("Game Over");
        parallaxController.ToggleActive(false);
        menu.GameOverScreen();
        visualControler.scoreActive = false;
        spawner.StopInvoke();
    }
    public void MainMenu()
    {
        parallaxController.ToggleActive(false);
        visualControler.scoreActive = true;
        menu.MainMenu();
        spawner.StopInvoke();
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] ParallaxController parallaxController;
    public void GameOver()
    {
        Debug.Log("F");
        //parallaxController.DisableParallax();
    }
}
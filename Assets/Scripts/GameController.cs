﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Range(0f, 0.20f)]
    public float parallaxSpeed = 0.02f;
    public RawImage fondo;
    public RawImage plataforma;
    public GameObject uiIdle;

    public enum GameState {Idle, Playing};
    public GameState gameState = GameState.Idle;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Inicia el juego
        if (gameState == GameState.Idle && (Input.GetKeyDown("up") || Input.GetMouseButtonDown(0)))
        {
            gameState = GameState.Playing;
            uiIdle.SetActive(false);
            player.SendMessage("UpdateState", "PlayerRun");
        }
        //Juego iniciado
        else
        {
            if (gameState == GameState.Playing)
            {
                Parallax();
            }
        }
    }

    void Parallax()
    {
        float finalSpeed = parallaxSpeed * Time.deltaTime;
        fondo.uvRect = new Rect(fondo.uvRect.x + finalSpeed, 0f, 1f, 1f);
        plataforma.uvRect = new Rect(plataforma.uvRect.x + finalSpeed * 3, 0f, 1f, 1f);
    }
}

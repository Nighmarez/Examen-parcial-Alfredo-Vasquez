using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juego : MonoBehaviour
{
    public delegate void DelegadoGameOver();
    public static event DelegadoGameOver OnGameOver;

    public Jugador jugador;

    private void Update()
    {
        bool isGameOver = jugador.Salud <= 0 ? true : false;
        if (isGameOver)
        {
            OnGameOver?.Invoke();
            Debug.Log("Game Over");
        }
    }
}
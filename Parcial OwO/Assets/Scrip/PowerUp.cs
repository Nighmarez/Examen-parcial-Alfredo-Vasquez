using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum TipoPowerUp { Vida, Velocidad, Fuerza }
    public TipoPowerUp tipoPowerUp;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AplicarPowerUp(other.GetComponent<Jugador>());
        }
    }

    private void AplicarPowerUp(Jugador jugador)
    {
        switch (tipoPowerUp)
        {
            case TipoPowerUp.Vida:
                jugador.Salud += 20;
                break;
            case TipoPowerUp.Velocidad:
                jugador.speed += 2;
                break;
            case TipoPowerUp.Fuerza:
                // Lógica para incrementar la fuerza
                break;
        }
        Destroy(gameObject);
    }
}
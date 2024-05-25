using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirJugador : MonoBehaviour
{
    public Transform jugador;
    public Vector3 offset; 

    void Update()
    {
        if (jugador != null)
        {
            transform.position = jugador.position + offset;
        }
    }
}
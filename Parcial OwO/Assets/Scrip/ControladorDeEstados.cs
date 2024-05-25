using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeEstados : MonoBehaviour
{
    private Estado estadoActual;

    private void Start()
    {
        estadoActual = new EstadoPatrullando(GetComponent<Enemigo>());
    }

    private void Update()
    {
        estadoActual.Ejecutar();
    }

    public void CambiarEstado(Estado nuevoEstado)
    {
        estadoActual = nuevoEstado;
    }
}
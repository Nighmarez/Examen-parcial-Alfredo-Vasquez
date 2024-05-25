using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoPatrullando : Estado
{
    private Enemigo enemigo;

    public EstadoPatrullando(Enemigo enemigo)
    {
        this.enemigo = enemigo;
    }

    public override void Ejecutar()
    {
        enemigo.Patrullar();
    }
}
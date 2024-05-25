using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoPersiguiendo : Estado
{
    private Enemigo enemigo;

    public EstadoPersiguiendo(Enemigo enemigo)
    {
        this.enemigo = enemigo;
    }

    public override void Ejecutar()
    {
        enemigo.Perseguir();
    }
}
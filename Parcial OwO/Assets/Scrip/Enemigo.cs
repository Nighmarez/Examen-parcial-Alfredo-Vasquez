using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : EntidadBase
{
    private ControladorDeEstados controladorDeEstados;
    public Jugador jugador;  
    public int dano = 10;
    public float rangoDePersecucion = 5f;
    public float rangoDeRegreso = 7f;
    public Transform puntoA;
    public Transform puntoB;

    private Vector3 puntoObjetivo;

    private void Awake()
    {
        controladorDeEstados = GetComponent<ControladorDeEstados>();
    }

    private void Start()
    {
        StartCoroutine(PatrullarRoutine());
    }

    public override void Mover()
    {
        transform.position = Vector3.MoveTowards(transform.position, puntoObjetivo, Time.deltaTime * 2);

        if (Vector3.Distance(transform.position, puntoObjetivo) < 0.1f)
        {
            CambiarObjetivo();
        }
    }
    private void CambiarObjetivo()
    {
        if (puntoObjetivo == puntoA.position)
        {
            puntoObjetivo = puntoB.position;
        }
        else
        {
            puntoObjetivo = puntoA.position;
        }
    }

    public void Patrullar()
    {
        Mover();
    }

    public void Perseguir()
    {
        transform.position = Vector3.MoveTowards(transform.position, jugador.transform.position, Time.deltaTime * 2);

        if (Vector3.Distance(transform.position, jugador.transform.position) > rangoDeRegreso)
        {
            controladorDeEstados.CambiarEstado(new EstadoPatrullando(this));
        }
    }

    private IEnumerator PatrullarRoutine()
    {
        while (true)
        {
            Patrullar();
            yield return new WaitForSeconds(2f);

            if (Vector3.Distance(transform.position, jugador.transform.position) < 5f)
            {
                controladorDeEstados.CambiarEstado(new EstadoPersiguiendo(this));
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Jugador jugador = collision.gameObject.GetComponent<Jugador>();
            if (jugador != null)
            {
                jugador.CambiarSalud(-dano); 
            }
        }
    }
}
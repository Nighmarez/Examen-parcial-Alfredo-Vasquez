using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : EntidadBase
{
    [Header("Configuraciones del Jugador")]
    public float speed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool isGrounded;
    private Animator anim;
    private bool isJumping;
    private bool Jump;
    public int salud = 100;

    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        if (move != 0f)
        {
            anim.SetBool("isWalking", true);
            if (move > 0f)
            {
                anim.SetBool("isWalking", true);
                transform.localScale = new Vector3(-0.6f, 0.6f, 0.6f);
            }
            else if (move < 0f)
            {
                anim.SetBool("isWalking", true);
                transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            }
            else
            {
                anim.SetBool("isWalking", false);
            }
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if (isGrounded)
        {
            isJumping = false;
            anim.SetBool("Jump", false);
        }

        if (!isJumping && isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.SetBool("Jump", true);
            isJumping = true;
        }

        if (!isGrounded)
        {
            isJumping = true;
            anim.SetBool("Jump", true);
        }
    }


    public void CambiarSalud(int cantidad)
    {
        salud += cantidad;
        salud = Mathf.Clamp(salud, 0, 100); 
        if (salud <= 0)
        {
            Morir();
        }
    }

    public int Salud
    {
        get { return salud; }
        set { salud = Mathf.Clamp(value, 0, 100); }
    }

    public void RecibirDano(int cantidad)
    {
        Salud -= cantidad;
    }

    public void RecibirDano(int cantidad, string fuente)
    {
        Salud -= cantidad;
        Debug.Log("Daño recibido de: " + fuente);
    }

    private void Morir()
    {
        Debug.Log("El jugador ha muerto");
    }
}
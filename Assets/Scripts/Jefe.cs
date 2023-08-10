using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jefe : MonoBehaviour
{

    private Animator animator;
    public Rigidbody2D rb2D;
    public Transform jugador;
    [SerializeField] private GameObject effectDead;

    private bool mirandoDerecha = true;

    [Header("Vida")]
    [SerializeField] private float vida;
    [SerializeField] private BarraVidaJefe barraDeVida;

    [Header("Ataque")]
    [SerializeField] private Transform controladorAtaque;
    [SerializeField] private float radioAtaque;
    [SerializeField] private float dañoAtaque;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        barraDeVida.InicializarBarraDeVida(vida);
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        float distanciaJugador = Vector2.Distance(transform.position, jugador.position);
        animator.SetFloat("distanciaJugador", distanciaJugador);
    }

    public void TomarDaño(float daño)
    {
        vida -= daño;

        barraDeVida.CambiarVidaActual(vida);

        if(vida <= 0)
        {
            animator.SetTrigger("Muerte");
            
        }
    }

    public void Muerte()
    {
        //Instantiate(effectDead, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    //Para mirar la position a la que este el player
    public void MirarJugador()
    {
        if ((jugador.position.x > transform.position.x && !mirandoDerecha) || (jugador.position.x < transform.position.x && mirandoDerecha))
        {
            mirandoDerecha = !mirandoDerecha;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
    }

    //Ataque Melee(si se va a utilizar)
    public void Ataque()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorAtaque.position, radioAtaque);

        foreach(Collider2D colision in objetos)
        {
            if(colision.CompareTag("Player"))
            {
                colision.GetComponent<EstadoJugador>().TomarDaño(dañoAtaque); 

            }
        }
    }

    //Dibuja un gizmo en la escena para saber la posicion a la que hara daño con la animacion de ataque
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorAtaque.position, radioAtaque);
    }
}

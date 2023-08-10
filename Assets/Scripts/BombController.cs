using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public GameObject bombPrefab;   // Prefab de la bomba
    public Transform bombSpawnPoint; // Punto desde donde se lanzar� 
    public float bombForce = 5f;     // Fuerza de lanzamiento 
    public float forwardForce = 2f;  // Fuerza hacia adelante 
    public float bombLifetime = 3f;  // Tiempo de vida del prefab (osea la bomba)

    private Vector2 playerDirection;  // Direcci�n en la que mira el jugador

    void Update()
    {
        // Actualizar la direcci�n del jugador seg�n el flip
        playerDirection = transform.right * (GetComponent<SpriteRenderer>().flipX ? -1 : 1);

        if (Input.GetKeyDown(KeyCode.F))
        {
            LanzarBomba();
        }
    }

    void LanzarBomba()
    {
        GameObject bomb = Instantiate(bombPrefab, bombSpawnPoint.position, Quaternion.identity);
        Rigidbody2D bombRigidbody = bomb.GetComponent<Rigidbody2D>();

        if (bombRigidbody != null)
        {
            // Aplicar una combinaci�n de fuerza hacia adelante y hacia arriba a la bomba
            bombRigidbody.AddForce((playerDirection * forwardForce + Vector2.up) * bombForce, ForceMode2D.Impulse);

            bombRigidbody.gravityScale = 1f; //gravedad de la bomba
        }

        // Destruir el prefab de la bomba despu�s del tiempo estimado por nosotros
        Destroy(bomb, bombLifetime);
    }
}
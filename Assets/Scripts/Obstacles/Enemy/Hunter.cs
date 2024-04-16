using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : MonoBehaviour
{
    public float movementSpeed = 5f; // Velocidad de movimiento del enemigo
    public float lookAtTime = 1f; // Tiempo que el enemigo mira al jugador antes de moverse hacia él
    public float stopTime = 3f; // Tiempo que el enemigo se detiene al llegar a la posición

    private Vector3 targetPosition = new Vector3(15, 0, 15); // Posición a la que el enemigo se mueve
    private Transform player; // Referencia al transform del jugador
    private bool isLooking = false; // Indica si el enemigo está mirando al jugador
    private float stopTimer = 0f; // Temporizador para detenerse al llegar a la posición
    private float lookTimer = 0f; // Temporizador para mirar al jugador

    void Start()
    {
        Destroy(gameObject, 15f);
        // Buscar el GameObject del jugador por su tag
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player == null)
        {
            Debug.LogError("Player GameObject not found!");
        }
        else
        {
            // Iniciar movimiento hacia la posición objetivo
            transform.LookAt(targetPosition);
        }
    }

    void Update()
    {
        if (!isLooking)
        {
            // Moverse hacia la posición objetivo
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
            // Continuar mirando al jugador
            transform.LookAt(player.position);

            // Si el enemigo llega a la posición objetivo
            if (transform.position == targetPosition)
            {
                // Incrementar el temporizador de detención
                stopTimer += Time.deltaTime;
                // Si el tiempo de detención ha pasado, comenzar a moverse en dirección al jugador
                if (stopTimer >= stopTime)
                {
                    isLooking = true;
                    // Reiniciar el temporizador de mirada
                    lookTimer = 0f;
                }
            }
        }
        else
        {
            // Incrementar el temporizador de mirada
            lookTimer += Time.deltaTime;
            // Si el tiempo de mirada ha pasado, moverse en dirección al jugador
            if (lookTimer >= lookAtTime)
            {
                transform.position += transform.forward * movementSpeed * Time.deltaTime;
            }
        }
    }
}
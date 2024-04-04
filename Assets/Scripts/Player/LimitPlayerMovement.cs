using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitPlayerMovement : MonoBehaviour
{
    float terrainSize = 5f;

    void Update()
    {
        // Obtener la posici�n actual del jugador
        Vector3 playerPosition = transform.position;

        // Limitar la posici�n en el eje X
        playerPosition.x = Mathf.Clamp(playerPosition.x, 0f, terrainSize);

        // Limitar la posici�n en el eje Z
        playerPosition.z = Mathf.Clamp(playerPosition.z, 0f, terrainSize);

        // Aplicar la nueva posici�n al jugador
        transform.position = playerPosition;
    }
}
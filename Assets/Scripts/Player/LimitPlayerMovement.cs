using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitPlayerMovement : MonoBehaviour
{
    float terrainSize = 5f;

    void Update()
    {
        // Obtener la posición actual del jugador
        Vector3 playerPosition = transform.position;

        // Limitar la posición en el eje X
        playerPosition.x = Mathf.Clamp(playerPosition.x, 0f, terrainSize);

        // Limitar la posición en el eje Z
        playerPosition.z = Mathf.Clamp(playerPosition.z, 0f, terrainSize);

        // Aplicar la nueva posición al jugador
        transform.position = playerPosition;
    }
}
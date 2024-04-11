using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float speed = 10f;
    public float maxHeight = 5f;
    public float minHeight = -5f;
    public float resetZ = 250f;
    public float minScale = 50f;
    public float maxScale = 200f;

    private Vector3 originalPosition;
    private Vector3 originalScale;
    private float randomHeight;

    private void Start()
    {
        originalPosition = transform.position;
        originalScale = transform.localScale;
        minHeight += originalPosition.y;
        maxHeight += originalPosition.y;
        randomHeight = Random.Range(minHeight, maxHeight);
    }

    private void Update()
    {
        transform.position -= new Vector3(0, 0, speed * Time.deltaTime);

        // Calcular la distancia desde la posición de reseteo
        float distanceFromReset = resetZ - transform.position.z;

        // Calcular el factor de escala basado en la distancia desde minScale a maxScale
        float scaleFactor = Mathf.Clamp01((transform.position.z - minScale) / (maxScale - minScale));

        // Aplicar el escalado entre 0 y 1 en el rango entre minScale y maxScale
        float scaledValue = Mathf.Lerp(0f, 1f, scaleFactor);

        // Aplicar el escalado al objeto
        transform.localScale = originalScale * scaledValue;

        // Si el objeto está más allá de la posición de reseteo
        if (transform.position.z < originalPosition.z)
        {
            // Restablecer la posición en X y asignar una nueva altura aleatoria
            transform.position = new Vector3(originalPosition.x, randomHeight, resetZ);
            randomHeight = Random.Range(minHeight, maxHeight);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float speed = 10f;
    public float maxHeight = 5f;
    public float minHeight = -5f;
    public float resetZ = 250f;
    public float offsetZ = -10f;
    public float maxScaleZ = 100f;

    private Vector3 originalPosition;
    private Vector3 originalScale;
    private float randomHeight;
    private float currentScaleZ = 0f;

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

        // Calcular la escala según la posición Z
        currentScaleZ = Mathf.Lerp(0f, 1f, (transform.position.z - resetZ) / (maxScaleZ - resetZ));
        transform.localScale = Vector3.Lerp(Vector3.zero, originalScale, currentScaleZ);

        if (transform.position.z < offsetZ)
        {
            // Reiniciar la posición y la escala
            transform.position = new Vector3(originalPosition.x, randomHeight, resetZ);
            transform.localScale = originalScale;
            randomHeight = Random.Range(minHeight, maxHeight);
        }
    }
}
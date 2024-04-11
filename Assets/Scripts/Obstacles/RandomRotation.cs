using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    float maxRotationSpeed = 10f;

    void Start()
    {
        Vector3 randomRotation = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;

        float rotationSpeed = Random.Range(1f, maxRotationSpeed);
        GetComponent<Rigidbody>().angularVelocity = randomRotation * rotationSpeed;
    }
}
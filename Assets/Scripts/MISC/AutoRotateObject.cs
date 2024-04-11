using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotateObject : MonoBehaviour
{
    public Vector3 rotationAxis = Vector3.up;
    public float rotationSpeed = 30f;

    void Update()
    {
        RotateObjectAround(rotationAxis, rotationSpeed * Time.deltaTime);
    }

    void RotateObjectAround(Vector3 axis, float angle)
    {
        transform.RotateAround(transform.position, transform.TransformDirection(axis), angle);
    }
}
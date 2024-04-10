using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    float speed = 10f;
    private void Update()
    {
        transform.position -= new Vector3(0, 0, speed * Time.deltaTime);

        if(transform.position.z < -10)
        {
            Destroy(gameObject);
        }
    }
}

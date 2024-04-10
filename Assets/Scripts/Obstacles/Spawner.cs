using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstacle;
    public float SpawnTime;
    public float Repetition;

    private void Start()
    {
        InvokeRepeating("Spawn", SpawnTime, Repetition);
    }

    void Spawn()
    {
        int RandomIndex = Random.Range(0, obstacle.Length);

        GameObject RandomObstacle = obstacle[RandomIndex];

        Instantiate(RandomObstacle, transform.position, Quaternion.identity);
    }
}
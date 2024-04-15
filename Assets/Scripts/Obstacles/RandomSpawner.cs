using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public Transform[] spawnPositions;
    public int minObjectsAmount = 1;
    public float spawnInterval = 5f;
    public float spawnDistanceZ = 150f;
    private void Start()
    {
        StopInvoke();
    }
    public void StartInvoke()
    {
        InvokeRepeating("SpawnObjects", 5f, spawnInterval);
    }
    public void StopInvoke()
    {
        CancelInvoke("SpawnObjects");
    }

    void SpawnObjects()
    {
        if (spawnInterval < 1) { spawnInterval = 1; }
        if (minObjectsAmount >= 9) { minObjectsAmount = 8; }
        int randomAmount = Random.Range(minObjectsAmount, 8);

        // Spawn the random amount of objects in random positions
        List<int> availablePositions = new List<int>();
        for (int i = 0; i < spawnPositions.Length; i++)
        {
            availablePositions.Add(i);
        }

        for (int i = 0; i < randomAmount; i++)
        {
            GameObject randomObject = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];

            // Select a random available position
            int randomPositionIndex = Random.Range(0, availablePositions.Count);
            int positionIndex = availablePositions[randomPositionIndex];
            availablePositions.RemoveAt(randomPositionIndex);

            // Get the spawn position with modified Z value
            Vector3 spawnPosition = spawnPositions[positionIndex].position;
            spawnPosition.z = spawnDistanceZ;

            // Spawn the object at the modified position
            Instantiate(randomObject, spawnPosition, Quaternion.identity);
        }
    }
}
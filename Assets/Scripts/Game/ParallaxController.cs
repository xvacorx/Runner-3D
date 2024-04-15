using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField] GameObject[] parallaxObjects;
    [SerializeField] ParticleSystem particleSystems;

    private ObjectMovement[] objectMovements;

    private void Start()
    {
        objectMovements = new ObjectMovement[parallaxObjects.Length];

        int index = 0;
        foreach (var obj in parallaxObjects)
        {
            objectMovements[index] = obj.GetComponent<ObjectMovement>();
            index++;
        }
    }

    public void ToggleActive(bool active)
    {
        for (int i = 0; i < objectMovements.Length; i++)
        {
            objectMovements[i].enabled = active;
        }
        if (particleSystems != null)
        {
            if (active)
            {
                particleSystems.Play();
            }
            else
            {
                particleSystems.Stop();
            }
        }
    }
}
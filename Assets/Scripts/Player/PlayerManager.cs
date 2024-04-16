using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    private int life;
    public GameObject explosion;

    [SerializeField] GameController gameController;
    [SerializeField] UIController visualController;

    private void Start()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        gameObject.GetComponent<MeshCollider>().enabled = true;
        life = 3;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            LoseLife();
            GameObject explosionEffect = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(explosionEffect, 0.5f);
            if (life < 1)
            {
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                gameObject.GetComponent<MeshCollider>().enabled = false;
                gameController.GameOver();
            }
            else
            {
                Destroy(other.gameObject);
            }
        } // Obstacles
        else if (other.gameObject.CompareTag("Life"))
        {
            Destroy(other.gameObject);
            AddLife();
        } // Extra Lives
    }
    public void AddLife()
    {
        life++;
        if (life >= 3) { life = 3; }
        visualController.UpdateLife(life);
    }
    public void LoseLife()
    {
        life--;
        visualController.UpdateLife(life);
    }
    public void Restart()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        gameObject.GetComponent<MeshCollider>().enabled = true;
        life = 3;
        visualController.UpdateLife(life);
    }
}
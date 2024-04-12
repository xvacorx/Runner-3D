using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int startingLife = 3;
    private int life;
    public GameObject explosion;

    [SerializeField] GameController gameController;
    [SerializeField] UIController visualController;
    private void Start()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        life = startingLife;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            //Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(explosion, 1f);
            if (life <= 1)
            {
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                life--;
                gameController.GameOver();
            }
            else
            {
                Destroy(other.gameObject);
                life--;
            }
            visualController.UpdateLife(life);
        }
    }
    public void AddLife(int hp)
    {
        life++;
        if (life >= 3) { life = 3; }
        visualController.UpdateLife(life);
    }
}
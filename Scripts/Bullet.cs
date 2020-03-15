 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameManager gameManager;
    public Rigidbody rb;

    private void OnCollisionEnter(Collision collision)
    {
        // Ef hitt kassa með obstacle tag
        if (collision.collider.tag == "Obstacle")
        {
            // Eyðir frá gameObject
            Destroy(collision.gameObject);
            // Óvirkar gameObject
            gameObject.SetActive(false);
            gameManager.AddPoints(100);
        }

        else if (collision.collider.name != "Player")
        {
            // Óvirkar gameObject
            gameObject.SetActive(false);
        }
    }

}

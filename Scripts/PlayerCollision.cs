using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;

    private void OnCollisionEnter(Collision collision)

    {
        // Ef hitt kassa með obstacle tag
        if (collision.collider.tag == "Obstacle")
        {
            // Ekki hægt að hreyfa
            movement.enabled = false;
            // Kallar á föll EndGame í GameManager
            FindObjectOfType<GameManager>().EndGame();
        }
    }

}

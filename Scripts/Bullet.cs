 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody rb;
    public int damage = 10;
    void Start()
    {
        // rb.velocity = transform.forward  * speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.name);
        // Ef hitt kassa með obstacle tag
        if (collision.collider.tag == "Obstacle")
        {
            // Eyðir frá gameObject
            Destroy(collision.gameObject);
            // Óvirkar gameObject
            gameObject.SetActive(false);

        }

        else if (collision.collider.name != "Player")
        {
            // Óvirkar gameObject
            gameObject.SetActive(false);
        }
    }

}

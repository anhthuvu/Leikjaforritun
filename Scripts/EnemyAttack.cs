using UnityEngine;
using UnityEngine.UI;

public class EnemyAttack : MonoBehaviour
{
    public GameManager gameManager;
    public Transform player;
    public float moveSpeed;
    public float playerDistance;

    // Update is called once per frame
    void Update()
    {
        // Finnur fjarlæg milli enemy og player
        playerDistance = Vector3.Distance(player.position, this.transform.position);
        if (playerDistance < 5000f)
        {
            // Enemy horfa á player
            Vector3 direction = player.position - this.transform.position;
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
        }
        if (playerDistance < 100f)
        {
            if (playerDistance > 1.8f)
            {
                // Kallar á föll chase
                chase();
            }
            else if (playerDistance < 1.8f)
            {
                // Kallar á föll attack
                attack();
            }
        }

        void chase()
        {
            // Enemy elta player
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

        void attack()
        {
            // Enemy snerta player
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    Debug.Log("attack");
                    // Missir stig
                    gameManager.AddPoints(-5);
                }
            }
        }
    }
}


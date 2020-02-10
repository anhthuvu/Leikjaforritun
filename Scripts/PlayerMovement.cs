using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]

    public GameManager gameManager;
    private Rigidbody rb;
    public float forwardForce = 500f;
    public float sidewaysForce = 120f;
    public Text countText;
    private int count;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
    }

    // Update is called once per frame
    void FixedUpdate()

    {
        // Ef ýtt er á upp örvatakkann eða w     
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey("w"))
        {
            // Fer áfram
            rb.AddForce(0, 0, forwardForce * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }

        // Ef ýtt er á niður örvatakkann eða s
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s"))
        {
            // Fer aftan
            rb.AddForce(0, 0, -forwardForce * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }

        // Ef ýtt er á hægri örvatakkann eða d
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
        {
            // Fer til hægri
            rb.AddForce(sidewaysForce * Time.fixedDeltaTime, 0, 0, ForceMode.VelocityChange);
        }

        // Ef ýtt er á vinstri örvatakkann eða a
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))
        {
            // Fer til vinstri
            rb.AddForce(-sidewaysForce * Time.fixedDeltaTime, 0, 0, ForceMode.VelocityChange);
        }

        // Ef ýtt er á space
        if (Input.GetKey(KeyCode.Space))
        {
            // Hoppar uppcon
            rb.AddForce(0, 20, 0);
        }

        // Snúa spilari
        if (Input.GetKey("j"))
        {
            Vector3 spin = new Vector3(0, 2, 0);
            transform.Rotate(spin, Space.World);
        }
        if (Input.GetKey("f"))
        {
            Vector3 spin = new Vector3(0, -2, 0);
            transform.Rotate(spin, Space.World);
        }

        //  Ef kassi dettur
        if (rb.position.y < -1f)
        {
            // Kallar á föll EndGame í GameManager
            FindObjectOfType<GameManager>().EndGame();    
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        // Ef hitt kassa með coin tag
        if (collision.collider.tag == "Coin")
        {
            // Gullpeningur hverfur
            collision.collider.gameObject.SetActive(false);
            // Færð stig
            count = count + 10;
            // Kallar í aðferðina
            SetCountText();
        }
    }

    //Aðferðin
    void SetCountText()
    { 
        countText.text = count.ToString();
        if (count >= 70)
        {
            // Gerir playerinn óvirkan
            this.enabled = false;
            gameManager.CompleteLevel();
        }
    }

}

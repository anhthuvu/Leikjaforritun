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
    public Text loseText;
    [SerializeField] private AudioClip m_CoinSound;
    [SerializeField] private AudioClip m_DeathSound;
    private AudioSource m_AudioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        loseText.text = "";
        m_AudioSource = GetComponent<AudioSource>();
    }

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

        //  Ef kassi dettur
        if (rb.position.y < -1f)
        {
            // Kemur hljóð
            m_AudioSource.clip = m_DeathSound;
            m_AudioSource.Play();
            // Birtist texta
            loseText.gameObject.SetActive(true);
            loseText.text = "LEIK LOKIÐ!!!";
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
            // Kemur hljóð
            m_AudioSource.clip = m_CoinSound;
            m_AudioSource.Play();
            // Færð stig
            gameManager.AddPoints(10);
        }
    }
}

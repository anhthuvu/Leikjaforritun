using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public class WaterCollision : MonoBehaviour
{
    public GameManager gameManager;
    public Text loseText;
    [SerializeField] private AudioClip m_DeathSound;
    private AudioSource m_AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        loseText.text = "";
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnTriggerEnter()
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

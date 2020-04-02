using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 1f;
    public GameObject completeLevelUI;
    public GameObject gameOverUI;
    public static ScoreManager instance;
    public TextMeshProUGUI text;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
	    }
    }

    // Update is called once per frame
    public void ChangeScore(int coinValue)
    {
        score += coinValue;
        if(score >= 500)
        {
            text.enabled = false;
            completeLevelUI.SetActive(true);
		}
        text.text = score.ToString();
    }

    public void EndGame()
    {
        // Restart leik ef leik lokinn
        if (gameHasEnded == false)
        {
            text.enabled = false;
            gameOverUI.SetActive(true);
            score = 0;
            gameHasEnded = true;
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        // Opnar næsta borð
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

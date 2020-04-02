using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 1f;
    public GameObject completeLevelUI;
    public Text loseText;
    public Text score;
    private static int points = 0;

    private void Start()
    {
        loseText.text = " ";
        score.text = "0";
        //points = 0;
    }

    // Reiknar og bæta við stig
    public void AddPoints(int amount)
    {
        score.text = " ";
        Debug.Log(score.text);
        points += amount;
        Debug.Log(points);// þetta virkar
        SetCountText();
        // Vinnur ef ná í 500
        if (points >= 500)
        {
            Debug.Log("win");
            LevelComplete();// virkar ekki
            Debug.Log("...");
        }
        if (points < 0)
        {
            EndGame();  
		}
    }

    void SetCountText()
    {
        // kemur error og birtist ekki 
        score.text = points.ToString();
        Debug.Log("nú ætti að standa"+score.text);
    }
    
    public void LevelComplete()
    {
        completeLevelUI.SetActive(true);
    }

    // Fall EndGame virkar nema þegar stig er minna en 0 (í if setning fall AddPoints)
    public void EndGame()
    {
        // Restart leik ef leik lokinn
        if (gameHasEnded == false)
        {
            score.gameObject.SetActive(false);
            loseText.gameObject.SetActive(true);
            loseText.text = "LEIK LOKIÐ!!!";
            points = 0;
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

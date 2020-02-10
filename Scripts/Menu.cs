using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        // Opnar næsta borð
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

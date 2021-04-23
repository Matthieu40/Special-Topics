using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public GameObject playerUI;
    public GameObject gameOverScreen;
    public void playAgain()
    {
        playerUI.SetActive(true);
        gameOverScreen.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void loadMenu()
    {
        Debug.Log("Exiting to menu");
        SceneManager.LoadScene("Menu");
    }
}

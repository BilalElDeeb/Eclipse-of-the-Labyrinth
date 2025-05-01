using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public GameObject gameLayout;

    public void gameOver()
    {
        Time.timeScale = 0;
        pauseMenu.gameObject.SetActive(false);
        gameOverMenu.gameObject.SetActive(true);
        gameLayout.gameObject.SetActive(false);
    }
}

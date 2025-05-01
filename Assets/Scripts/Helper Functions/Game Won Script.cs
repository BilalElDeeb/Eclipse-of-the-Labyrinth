using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWonScript : MonoBehaviour
{
    
    NetworkManager networkManager;

    private void Awake()
    {
        networkManager = NetworkManager.Instance;
    }

    
    
    void OnTriggerEnter2D (Collider2D target)
    {
        if (target.tag == "Player" )
        {
            Time.timeScale = 0;
            GameWonInstanceHelper.canvas.GetComponent<GameWonInstanceHelper>().gameWonInstance.SetActive(true);
            GameWonInstanceHelper.canvas.GetComponent<GameWonInstanceHelper>().gameLayout.SetActive(false);
            networkManager.currentDungeonDifficulty += 1;
            networkManager.SaveDungeonDifficulty();
        }
    }
}

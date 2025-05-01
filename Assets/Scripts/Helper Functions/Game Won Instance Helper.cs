using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWonInstanceHelper : MonoBehaviour
{
    public GameObject gameWonInstance;
    public GameObject gameLayout;
    public static GameObject canvas;
    
    public void Awake()
    {
        if (canvas == null)
        {
            canvas = gameObject;
        }
        else
        {
            Debug.LogError("More than one Inventory singleton");
        }
    }
}

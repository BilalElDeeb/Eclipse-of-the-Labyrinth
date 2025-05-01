using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSliderUI : MonoBehaviour
{
    public Slider PlayerHealthSlider;
    public PlayerHealth PlayerHealth;
    
    // Start is called before the first frame update
    void Awake()
    {
        PlayerHealth.onHealthChangedCallback += updatePlayerHealthSlider;
    }

    void updatePlayerHealthSlider()
    {
        PlayerHealthSlider.maxValue = PlayerHealth.maxHealth;
        
        PlayerHealthSlider.value = PlayerHealth.currentHealth;
    }
}

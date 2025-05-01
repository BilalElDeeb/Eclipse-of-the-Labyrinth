using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    public Animator animator;
    public delegate void OnHealthChanged();
    public OnHealthChanged onHealthChangedCallback;

    void Awake()
    {
        currentHealth = maxHealth;
        animator.SetFloat("Health", currentHealth);
    }

    void Start()
    {
        if (onHealthChangedCallback != null)
        {
            onHealthChangedCallback();
        }
    }

    public void takeDamage(float damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hurt");
        animator.SetFloat("Health", currentHealth);
        
        if (onHealthChangedCallback != null)
        {
            onHealthChangedCallback();
        }
    }

    public void heal(float heal)
    {
        currentHealth += heal;
        animator.SetFloat("Health", currentHealth);
        
        if (onHealthChangedCallback != null)
        {
            onHealthChangedCallback();
        }
    }
}

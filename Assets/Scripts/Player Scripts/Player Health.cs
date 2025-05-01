using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    private float currentHealth;
    public Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void takeDamage(float damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hurt");
        animator.SetFloat("Health", currentHealth);
    }

    void heal(float heal)
    {
        currentHealth += heal;
        animator.SetFloat("Health", currentHealth);
    }
}

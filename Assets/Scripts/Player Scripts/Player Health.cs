using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    [SerializeField] protected float currentHealth;
    public Animator animator;

    void Awake()
    {
        currentHealth = maxHealth;
        animator.SetFloat("Health", currentHealth);
    }

    public void takeDamage(float damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hurt");
        animator.SetFloat("Health", currentHealth);
    }

    public void heal(float heal)
    {
        currentHealth += heal;
        animator.SetFloat("Health", currentHealth);
    }
}

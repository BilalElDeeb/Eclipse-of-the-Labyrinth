using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is an abstract class

public class EnemyAI : MonoBehaviour
{
    protected Animator animator;
    protected GameObject player;
    public Rigidbody2D enemyRigidbody;
    public float maxHealth;
    protected float currentHealth;
    public float speed;
    public Transform bulletSpawnLocation;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        
        currentHealth = maxHealth;
        animator.SetFloat("Health", currentHealth);
    }

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyRigidbody = GetComponent<Rigidbody2D>();
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

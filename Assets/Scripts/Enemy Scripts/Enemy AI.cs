using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is an abstract class

public class EnemyAI : MonoBehaviour
{
    protected Animator animator;
    protected GameObject player;
    protected Rigidbody2D enemyRigidbody;
    public float maxHealth;
    protected float currentHealth;
    public float speed;
    public Transform bulletSpawnLocation;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }
}

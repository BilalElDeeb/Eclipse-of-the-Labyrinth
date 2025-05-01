using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public FixedJoystick joystick;
    public float speed;
    public Animator animator;
    public GameObject playerSprite;

    [SerializeField] private Rigidbody2D rb;
    // Start is called before the first frame update
    private Vector2 movement;
    void Start()
    {
        
    }

    private void Update()
    {
        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;
        movement *= (speed * Time.deltaTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(movement.x, movement.y, 0.0f);
        if (movement == Vector2.zero)
        {
            rb.velocity = Vector2.zero;
        }
        animator.SetFloat("Speed", Mathf.Abs(movement.x) + Mathf.Abs(movement.y));

        playerSprite.transform.rotation = Quaternion.Euler(0, movement.x >= 0 ? 0 : 180, 0);
    }
}

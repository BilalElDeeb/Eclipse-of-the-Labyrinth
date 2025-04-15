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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = joystick.Horizontal * speed;
        float vertical = joystick.Vertical * speed;
        
        transform.Translate(horizontal, vertical, 0.0f);
        
        animator.SetFloat("Speed", Mathf.Abs(horizontal) + Mathf.Abs(vertical));

        if (horizontal >= 0)
        {
            playerSprite.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            playerSprite.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}

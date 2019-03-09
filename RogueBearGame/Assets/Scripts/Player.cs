using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MovingObject
{
    private GameObject player;
    private Animator animator;

    private float playerSpeed = 3.0f;

    void Start()
    {
        player = this.gameObject;
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        Side direction = Side.Idle;
        int keyCount = 0;
        ResetAnimationBools();

        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                direction = Side.Up;
                keyCount++;
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                direction = Side.Down;
                keyCount++;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                direction = Side.Left;
                keyCount++;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                direction = Side.Right;
                keyCount++;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                keyCount++;
            }
        }
        

        if (keyCount == 1)
        {
            
            MoveObject(player, direction, playerSpeed);
            AnimatePlayer(direction);

        }
        
        

    }

    void AnimatePlayer(Side movingSide)
    {
        string direction = "";
        switch (movingSide)
        {
            case Side.Up:
                direction = "isMovedUp";
                break;
            case Side.Down:
                direction = "isMovedDown";
                break;
            case Side.Left:
                direction = "isMovedLeft";
                break;
            case Side.Right:
                direction = "isMovedRight";
                break;
            default:
                break;
        }

        animator.SetBool(direction, true);
    }

    void ResetAnimationBools()
    {
        animator.SetBool("isMovedUp", false);
        animator.SetBool("isMovedDown", false);
        animator.SetBool("isMovedLeft", false);
        animator.SetBool("isMovedRight", false);
    }
}

    

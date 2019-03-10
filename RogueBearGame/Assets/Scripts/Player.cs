using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MovingObject
{
    private GameObject player;
    private Animator animator;

    public int id { get; set; }



    private KeyCode[] EventKeys =
    {
        KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow,KeyCode.Space
    };


    void Start()
    {
        player = this.gameObject;
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

   
    // Update is called once per frame
    void Update()
    {
        ResetAnimationFlags();

        Side direction = Side.Idle;

        bool playerEvent = false;
        KeyCode pressedKey = KeyCode.None;
        if (MyGameManager._roundEnded)
        {
            if (Input.anyKey)
            {
                foreach (var key in EventKeys)
                {
                    if (Input.GetKey(key))
                    {
                        playerEvent = true;
                        pressedKey = key;
                        break;
                    }
                }

                if (playerEvent)
                {
                    switch (pressedKey)
                    {
                        case KeyCode.UpArrow:
                            direction = Side.Up;
                            break;
                        case KeyCode.DownArrow:
                            direction = Side.Down;
                            break;
                        case KeyCode.LeftArrow:
                            direction = Side.Left;
                            break;
                        case KeyCode.RightArrow:
                            direction = Side.Right;
                            break;
                    }


                    bool isPlayerMoved = AttempMove(player, direction);
                    if (isPlayerMoved)
                    {
                        AnimatePlayer(direction);
                        MyGameManager._roundEnded = false;
                    }


                }

            }
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

    private void ResetAnimationFlags()
    {
        animator.SetBool("isMovedUp", false);
        animator.SetBool("isMovedDown", false);
        animator.SetBool("isMovedLeft", false);
        animator.SetBool("isMovedRight", false);
    }

    private bool isPlayerDoEvent(KeyCode pressedKey)
    {
        bool _isPlayerDoEvent = false;
        foreach (var key in EventKeys)
        {
            if (key == pressedKey)
            {
                _isPlayerDoEvent = true;
            }
        }
        return _isPlayerDoEvent;
    }
}

    

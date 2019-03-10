using System.Collections;
using System.Collections.Generic;
using  System;
using UnityEngine;
using UnityEngine.XR.WSA.Persistence;
using Random = UnityEngine.Random;

public class Enemy : MovingObject
{

    private GameObject enemy;
    private Animator animator;


    private Vector3 playerPosition;

    void Start()
    {
        enemy = this.gameObject;
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        MyGameManager.instance.AddEnemyToList(this);
    }




    void Update()
    {


    }

    void GetPlayerPosition()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
    }


    public Side RandomSide()
    {
        Array values = Enum.GetValues(typeof(Side));
        Side randomSide = (Side) values.GetValue(Random.Range(0, values.Length - 1));
        return randomSide;
    }

    public void MoveEnemy()
    {
        if (!MyGameManager._roundEnded)
        {
            bool enemyMoved;
            do
            {
                Side randomSide = RandomSide();
                enemyMoved = AttempMove(enemy, randomSide);
            } while (!enemyMoved);

            MyGameManager._roundEnded = true;
        }
    }



}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MovingObject
{
    private GameObject player;


    void Start()
    {
        player = this.gameObject;
        boxCollider = GetComponent<BoxCollider2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {

            if (Input.GetKey(KeyCode.UpArrow))
            {
                MoveObject(player,Side.Up);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                MoveObject(player, Side.Down);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                MoveObject(player, Side.Left);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                MoveObject(player, Side.Right);
            }
            else if (Input.GetKey(KeyCode.Space))
            {

            }
        }
    }

    

}

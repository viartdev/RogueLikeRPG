using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardGenerate : MonoBehaviour
{
    public GameObject FloorTile;
    public GameObject WallTile;
    private Transform boardHolder;

    public int xSize { get; set; } = 10;
    public int ySize { get; set; } = 10;

    private List<Vector3> freeCells;

    void Start()
    {
        GenerateStaticObjects();
    }

    public void GenerateStaticObjects()
    {
        boardHolder = new GameObject("Board").transform;
        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                if (x == 0 || x == xSize-1 || y == 0 || y == ySize-1)
                {
                    InstantiateObject(WallTile,x,y);
                }
                else
                {
                    InstantiateObject(FloorTile,x,y);
                }
            }
        }
    }

    void InstantiateObject(GameObject gameObject, int x, int y)
    {
        GameObject instanse = Instantiate(gameObject, new Vector3(x, y, 0.0f), Quaternion.identity);
        instanse.transform.SetParent(boardHolder);
    }


    /*
   

    // Update is called once per frame
    void Update()
    {
        
    }
    */

}

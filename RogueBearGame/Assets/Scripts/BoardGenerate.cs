using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardGenerate : MonoBehaviour
{
    public GameObject FloorTile;
    public GameObject WallTile;
    public GameObject Enemy;



    private Transform boardHolder;

    public int xSize { get; set; } = 10;
    public int ySize { get; set; } = 10;

    private List<Vector3> freeCells;
    
   

    public void SetupScene()
    {
        FillInnerCellsList();
        GenerateStaticObjects();
        int wallCount = Random.Range(1, 10);
        GenerateRandomObjects(WallTile, wallCount);
        GenerateRandomObjects(Enemy,2);
    }


    private void FillInnerCellsList()
    {
        freeCells = new List<Vector3>();
        freeCells.Clear();
        for (int x = 2; x < xSize-2; x++)
        {
            for (int y = 2; y < ySize-2; y++)
            {
                Vector3 freeCell = new Vector3(x,y,0.0f);
                freeCells.Add(freeCell);
            }
        }
    }

    Vector3 RandomPosition()
    {
        Vector3 _position;
        int index = Random.Range(0, freeCells.Count);
        _position = freeCells[index];
        freeCells.RemoveAt(index);
        return _position;
    }

    void GenerateRandomObjects(GameObject gameObject, int count)
    {
        
        for (int i = 0; i < count; i++)
        {
            Vector3 position = RandomPosition();

             InstantiateBoardObjects(gameObject,(int)position.x,(int)position.y);
        }
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
                    InstantiateBoardObjects(WallTile,x,y);
                }
                else
                {
                    InstantiateBoardObjects(FloorTile,x,y);
                }
            }
        }
    }

    void InstantiateBoardObjects(GameObject gameObject, int x, int y)
    {
        GameObject instanse = Instantiate(gameObject, new Vector3(x, y, 0.0f), Quaternion.identity);
        instanse.transform.SetParent(boardHolder);
    }

    void InstantiateObjectByVector(GameObject gameObject,Vector3 position)
    {
        Instantiate(gameObject, position, Quaternion.identity);
    }

    



    


    /*
   

    // Update is called once per frame
    void Update()
    {
        
    }
    */

}

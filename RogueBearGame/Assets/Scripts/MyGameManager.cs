using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class MyGameManager : MonoBehaviour
{

    public static bool _roundEnded = true;
    public static int PersonsCount = 3;

    private BoardGenerate boardScript;
    public static MyGameManager instance = null;

    private bool enemiesMoving;
    private float turnDelay = 0.1f;

    private List<Enemy> enemies;

    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        //Assign enemies to a new List of Enemy objects.
        enemies = new List<Enemy>();

        //Get a component reference to the attached BoardManager script
        boardScript = GetComponent<BoardGenerate>();

        //Call the InitGame function to initialize the first level 
        InitGame();
    }



    void InitGame()
    {
        enemies.Clear();

        //Call the SetupScene function of the BoardManager script, pass it current level number.
        boardScript.SetupScene();
    }

    void Update()
    {
        if (_roundEnded|| enemiesMoving)
        return;
        StartCoroutine(MoveEnemies());
    }

  

    public void AddEnemyToList(Enemy script)
    {
        //Add Enemy to List enemies.
        enemies.Add(script);
    }

    IEnumerator MoveEnemies()
    {
        //While enemiesMoving is true player is unable to move.
        enemiesMoving = true;

        //Wait for turnDelay seconds, defaults to .1 (100 ms).
        yield return new WaitForSeconds(turnDelay);

        //If there are no enemies spawned (IE in first level):
        if (enemies.Count == 0)
        {
            //Wait for turnDelay seconds between moves, replaces delay caused by enemies moving when there are none.
            yield return new WaitForSeconds(turnDelay);
        }

        //Loop through List of Enemy objects.
        for (int i = 0; i < enemies.Count; i++)
        {
            //Call the MoveEnemy function of Enemy at index i in the enemies List.
            enemies[i].MoveEnemy();

            //Wait for Enemy's moveTime before moving next Enemy, 
            yield return new WaitForSeconds(enemies[i].moveTime);
        }
        //Once Enemies are done moving, set playersTurn to true so player can move.
        MyGameManager._roundEnded = true;

        //Enemies are done moving, set enemiesMoving to false.
        enemiesMoving = false;
    }





    //private 


    // 
    // InstantiateObjectByVector(Player,new Vector3(1.0f,1.0f,0.0f));



}

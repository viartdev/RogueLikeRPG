using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public GameObject GameStarter;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(GameStarter);
    }
  
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject EnemyRow;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectsOfType<enemyScript>().Length == 0)
        {
            Instantiate(EnemyRow, new Vector2(0,6), Quaternion.identity);
        }        
    }

    //copyright PointZeroStudios
}

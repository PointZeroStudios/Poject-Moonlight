using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRowScript : MonoBehaviour
{

    public float approachSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position -= new Vector3(0, approachSpeed * Time.deltaTime, 0);

        if(transform.position.y < -8)
        {
            Destroy(gameObject);
        }

        if(transform.childCount == 0)
        {
            Destroy(gameObject);
        }
    }

    //copyright PointZeroStudios
}

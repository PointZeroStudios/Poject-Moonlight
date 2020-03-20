using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    Rigidbody2D rb;

    public float FlySpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {
        float speed = FlySpeed * Time.deltaTime;

        rb.velocity = new Vector2(0, speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<enemyScript>() != null)
        {
            collision.gameObject.GetComponent<enemyScript>().Enemydie();
        }
    }
    //copyright PointZeroStudios
}

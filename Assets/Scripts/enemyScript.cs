using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    ScoreManager score;
    SpriteRenderer spr;
    Rigidbody2D rb;

    public float speed;

    public Sprite[] spriteVariations;
    public int currentdir;
    // Start is called before the first frame update
    void Start()
    {
        score = FindObjectOfType<ScoreManager>();
        spr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        setRandomSprite();
    }

    private void setRandomSprite()
    {
        int Randomizer = Random.Range(0, 20);
        int spriteVer = 0;
        if(Randomizer == 19)
        {
            spriteVer = 3;
        }else if(Randomizer == 18 || Randomizer == 17 || Randomizer == 16 || Randomizer == 15)
        {
            spriteVer = 2;
        }else if(Randomizer == 14 || Randomizer == 13 || Randomizer == 12 || Randomizer == 11 || Randomizer == 10 || Randomizer == 9)
        {
            spriteVer = 1;
        }
        else
        {
            spriteVer = 0;
        }
        

        spr.sprite = spriteVariations[spriteVer];
    }

    // Update is called once per frame
    void Update()
    {
        changeDirection();
    }

    public void changeDirection()
    {
        switch (currentdir)
        {
            case 0:
                rb.velocity = new Vector2(-speed, 0);
                break;
            case 1:
                rb.velocity = new Vector2(speed, 0);
                break;
            case 2:
                rb.velocity = new Vector2(-speed * 3f, 0);
                break;
            case 3:
                rb.velocity = new Vector2(speed * 3f, 0);
                break;
        }
    }

    public void Enemydie()
    {
        if(spr.sprite.name == "Enemy")
        {
            score.Score += 100;
        } else if (spr.sprite.name == "Enemy1")
        {
            score.Score += 200;
        } else if (spr.sprite.name == "Enemy2")
        {
            score.Score += 500;
        } else if (spr.sprite.name == "Enemy3")
        {
            score.Score += 1000;
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.GetComponent<PlayerScript>() != null)
        {
            if (collision.transform.position.x > transform.position.x)
            {
                currentdir = 1;
            }
            if (collision.transform.position.x < transform.position.x)
            {
                currentdir = 0;
            }
        }

        //if a bullet is in range move away
        if (collision.GetComponent<BulletScript>() != null)
        {
            //if bullet is in range & im in the direct way choose random dir
            if(collision.transform.position.x == transform.position.x)
            {
                    if(collision.transform.GetComponent<enemyScript>().transform.position.x > transform.position.x)
                    {
                        currentdir = 2;
                    } else if(collision.transform.GetComponent<enemyScript>().transform.position.x < transform.position.x)
                    {
                        currentdir = 3;
                    }
            }
            //if bullet in range & its a little to the right go left
            else if (collision.transform.position.x >= transform.position.x)
            {
                currentdir = 0;
            }
            //if bullet in range & its a little to the left go Right
            else if (collision.transform.position.x <= transform.position.x)
            {
                currentdir = 1;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "barriers")
        {
            if(currentdir == 0 || currentdir == 2)
            {
                currentdir = 1;
            }else if(currentdir == 1 || currentdir == 3)
            {
                currentdir = 0;
            }
        }

        if(collision.gameObject.GetComponent<enemyScript>() != null)
        {
                if(collision.transform.position.x > transform.position.x)
                {
                    currentdir = 0;
                    //collision.gameObject.GetComponent<enemyScript>().currentdir = 1;
                    Debug.Log("dirChange");
                } else if (collision.transform.position.x < transform.position.x)
                {
                    currentdir = 1;
                    //collision.gameObject.GetComponent<enemyScript>().currentdir = 0;
                    Debug.Log("dirChange");
                }
        }
    }

    //copyright PointZeroStudios
}

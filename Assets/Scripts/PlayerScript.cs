using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed;

    public GameObject Lazer1;
    private float CurrentAttackCooldown;
    public float AttackCooldownReq;
    public float cooldownspeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(gyro.attitude);

        if(CurrentAttackCooldown < AttackCooldownReq)
        {
            CurrentAttackCooldown += cooldownspeed * Time.deltaTime;
        }


        if (Input.GetMouseButton(0))
        {
            if (CurrentAttackCooldown >= AttackCooldownReq)
            {
                attack();
            }
        }

        float xkeyboard = Input.GetAxisRaw("Horizontal") * speed;

        rb.velocity = new Vector2(xkeyboard, 0);

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {

                Vector3 TouchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                TouchPosition.z = 0;
                transform.position = TouchPosition;

                if(CurrentAttackCooldown >= AttackCooldownReq)
                {
                    attack();
                }
            }
        }
    }

    public void attack()
    {
        Debug.Log("boom Headshot");

        Instantiate(Lazer1, new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        
        CurrentAttackCooldown = 0;


    }
    //copyright PointZeroStudios
}

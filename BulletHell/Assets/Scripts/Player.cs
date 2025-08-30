using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    Weapon[] weapons;

    public float moveSpeed = 1f;
    private Rigidbody2D rb;
    private Vector2 input;

    bool shoot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        weapons = transform.GetComponentsInChildren<Weapon>();
        foreach (Weapon weapon in weapons)
        {
            weapon.isActive = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        input.Normalize();

        shoot = Input.GetKeyDown(KeyCode.Z);
        if(shoot)
        {
            shoot = false;
            foreach(Weapon weapon in weapons)
            {
                weapon.Shoot();
            }
        }

    }
        

    private void FixedUpdate()
    {
         rb.linearVelocity = input * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.GetComponent<Bullet>();
        if( bullet != null )
        {
            if(bullet.Enemy)
            {
                Destroy(gameObject);
                Destroy(bullet.gameObject);
            }
        }

        Destructable destructable = collision.GetComponent<Destructable>();
        if (destructable != null)
        {
            Destroy(gameObject);
            Destroy(destructable.gameObject);
        }

        SinMovement sinBullets = collision.GetComponent<SinMovement>();
        if( sinBullets != null )
        {
            Destroy(gameObject);
            Destroy(sinBullets.gameObject);
        }
    }
}

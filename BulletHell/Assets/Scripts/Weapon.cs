using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Bullet bullet;
    Vector2 direction;

    public bool autoShoot = false;
    public float shootInterval = 0.5f;
    public float shootDelay = 0f;
    float shootTimer = 0f;
    float DelayTimer = 0f;

    public bool isActive = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isActive)
        {
            return;
        }

        direction = (transform.localRotation * Vector2.right).normalized;


        if(autoShoot)
        {
            if (DelayTimer >= shootDelay)
            {
                if(shootTimer >= shootInterval)
                {
                    Shoot();
                    shootTimer = 0;
                }
                else
                {
                    shootTimer += Time.deltaTime;
                }
            }
            else
            {
                DelayTimer += Time.deltaTime;
            }
        }
    }

    public void Shoot()
    {
        GameObject go = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
        Bullet goBullet = go.GetComponent<Bullet>();
        goBullet.direction = direction;
    }
}

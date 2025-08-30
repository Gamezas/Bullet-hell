using Unity.VisualScripting;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    bool Destroyable = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < 8.2 && !Destroyable)
        {
            Destroyable = true;
            Weapon[] weapons = transform.GetComponentsInChildren<Weapon>();
            foreach(Weapon weapon in weapons)
            {
                weapon.isActive = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!Destroyable)
        {
            return;
        }

        Bullet bullet = collision.GetComponent<Bullet>();
        if(bullet != null)
        {
            if(!bullet.Enemy)
            {
                Destroy(gameObject);
                Destroy(bullet.gameObject);
            }
            
        }
    }
}

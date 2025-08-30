using Unity.VisualScripting;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    bool Destroyable = false;
    public bool Boss = false;
    int hp = 100;

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

        if (Boss)
        {
            if (!bullet.Enemy)
            {
                hp -= 1;
                Destroy(bullet.gameObject);
                if(hp == 0)
                {
                    Destroy(gameObject);
                }
            }

            return;
        }

        if (bullet != null)
        {
            if(!bullet.Enemy)
            {
                gameObject.SetActive(false);
                Destroy(bullet.gameObject);
                respawn();
            }
            
        }
    }

    void respawn()
    {
        gameObject.SetActive (true);
        transform.position = new Vector2(11, 0);

    }
}

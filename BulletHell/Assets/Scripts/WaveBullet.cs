using UnityEngine;

public class WaveBullet : MonoBehaviour
{

    public float moveSpeed = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos.x -= moveSpeed * Time.fixedDeltaTime;

        transform.position = pos;

        if(pos.x < -10)
        {
            Destroy(gameObject);
        }
    }
}

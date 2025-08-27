using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private const float MAX_LIFE_TIME = 3f;
    private float _lifeTime = 0f;


    public Vector2 Velocity;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)Velocity * Time.deltaTime;
        _lifeTime += Time.deltaTime;

        if (_lifeTime > MAX_LIFE_TIME)
            Disable();
    }

    private void Disable()
    {
        Destroy(gameObject);
    }
}

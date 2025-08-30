using UnityEngine;

public class SinMovement : MonoBehaviour
{
    float sinCenterY;
    public float amplitude = 2;
    public float frecuency = 2;

    public bool inverted = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sinCenterY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        float sin = Mathf.Sin(pos.x * frecuency) * amplitude;
        if (inverted)
        {
            sin *= -1;
        }
        pos.y = sinCenterY + sin;

        transform.position = pos;
    }
}

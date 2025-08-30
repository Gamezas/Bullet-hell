using UnityEngine;

public class BossMovement : MonoBehaviour
{
    float sinCenterY;
    public float amplitude = 2;
    public float speed = 2;

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
        Vector3 pos = transform.position;

        float sin = Mathf.Sin(Time.time * speed) * amplitude;
        pos.y = sinCenterY + sin;

        transform.position = pos;
    }
}

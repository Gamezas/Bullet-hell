using UnityEngine;
using UnityEngine.UI;

public class BulletCounter : MonoBehaviour
{
    public Text bulletCountText;
    public string bulletTag = "Bullet";

    void Update()
    {
        int count = BulletCount();
        bulletCountText.text = count.ToString();
    }

    int BulletCount()
    {
        GameObject[] bullets = GameObject.FindGameObjectsWithTag(bulletTag);

        return bullets.Length;
    }
}

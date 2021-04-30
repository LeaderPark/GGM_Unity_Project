using UnityEngine;

public class cannonball : MonoBehaviour
{
    private Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void Shoot(Vector2 direction, float power)
    {
        rigid.AddForce(direction * power);
    }
}
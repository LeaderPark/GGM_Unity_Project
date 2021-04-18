using UnityEngine;

public class TargetBox : MonoBehaviour
{   
    public float hp = 50f;
    public GameObject destroyObj;

    public void TakeDamage(float amount)
    {
        hp -= amount;
        if(hp <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(destroyObj, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }
}
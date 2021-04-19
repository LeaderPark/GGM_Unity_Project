using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    public float hp = 100f;
    public GameObject bloodEffect;

    public void OnDamage(float damage, Vector3 po, Vector3 normal)
    {
        hp -= damage;
        GameObject effect = Instantiate(bloodEffect,po, Quaternion.LookRotation(normal),this.transform);
        Destroy(effect, 1f);
        
        if(hp<= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Destroy(this.gameObject);
    }
}

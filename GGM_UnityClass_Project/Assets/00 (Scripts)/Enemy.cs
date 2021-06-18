using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHP = 100;
    
    public void TakeDamage(int Damage)
    {
        if(enemyHP > 0)
        {
            enemyHP -= Damage;
        }
        else
        {
            Die();
        }
    }

    void Die(){
        
    }
}

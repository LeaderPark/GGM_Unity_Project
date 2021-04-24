using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFighter : Enemy
{
    public EnemyFighter()
    {
        this.maxHp = this.currentHp = 20;
    }
    
    public void Attack()
    {
        Debug.Log("공격 시작");
    }
    
    protected override void Dead() 
    {
        Debug.Log("아오옥");
    }
}

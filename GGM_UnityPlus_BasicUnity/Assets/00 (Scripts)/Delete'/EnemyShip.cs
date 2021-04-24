using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : Enemy
{
    public EnemyShip()
    {
        this.maxHp = this.currentHp = 20;
    }

    public void Teleport(float x, float y)
    {
        this.currentX = x;
        this.currentY = y;
    }
    
    public void Attack()
    {
        Debug.Log("폭격 시작");
    }

    protected override void Dead() 
    {
        Debug.Log("꾸에엑");
    }
    
}

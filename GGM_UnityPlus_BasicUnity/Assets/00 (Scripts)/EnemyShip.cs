using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip 
{
    public float currentX;
    public float currentY;
    public float moveSpeed;
    public float maxHp;
    public float damage;

    private float currentHp;
    private Vector2 moveDir;

    public void teleport(float x, float y)
    {
        this.currentX = x;
        this.currentY = y;
    }
    public void move(float x, float y)
    {
        this.currentX += x;
        this.currentY += y;
    }
    public void hit(float damage)
    {
        this.currentHp -= damage;
    }
    public void attack()
    {
        Debug.Log("폭격 시작");
    }

    private void dead()
    {
        Debug.Log("사망");
    }
}

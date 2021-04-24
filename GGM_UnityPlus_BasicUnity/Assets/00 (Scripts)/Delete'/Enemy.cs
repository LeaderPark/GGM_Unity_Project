using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy 
{
    public float currentX;
    public float currentY;
    public float moveSpeed;
    public float maxHp;
    public float damage;

    protected float currentHp;
    protected Vector2 moveDir;

    public void Move(float x, float y)
    {
        this.currentX += x;
        this.currentY += y;
    }
    public void Damaged(float damage)
    {
        this.currentHp -= damage;
        if(currentHp <= 0)
        {
            Dead();
        }
    }

    protected abstract void Dead(); 
    //virtual은 가상함수로 자식 클래스에 같은 것이 있으면 덮어씌워서 실행된다. 우선권이 낮아짐 
    //virtual은 애매하지만 abstract는 

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp = 5f;

    private void OnParticleCollision(GameObject other) {
        Damage();    
    }

    void Damage()
    {
        hp --;
        if(hp <= 5f)
        {
            hp = 5f;
            gameObject.SetActive(false);
            //리스폰 처리
            Invoke("Respawn", 3f);
        }
    }

    void Respawn()
    {
        gameObject.SetActive(true);
    }
}

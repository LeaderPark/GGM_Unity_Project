using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float speed = 10f;
    public float hp = 4f;

    public Enemy enemys = null;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);

        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
        //if(enemys.EnemyList[9])
        //{
        //    StopCoroutine(enemys.CreateEnemy());
        //}
    }
    

    public void OnDamage()
    {

    }
}

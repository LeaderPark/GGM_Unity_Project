using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    public GameObject enemy;

    public Enemy enemys = null;

    float nextTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Click()
    {
        if (Time.time >= nextTime)
        {
            nextTime = Time.time + 0.1f;
            EnemyBehavior temp = enemys.EnemyList[0];
            if (temp.hp != 0)
            {
                temp.hp--;
               // Debug.Log("죽음");
            }
            else
            {
                enemys.EnemyList.Remove(temp);
                Destroy(temp.gameObject);
            }
        }

        


    }
}

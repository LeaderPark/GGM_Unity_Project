using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    float LevelUpCost;
    int  Power;
    float Level;
    bool colTime;


    public Transform enemy;

    private void Awake() 
    {
        LevelUpCost = 50 * ((int)Mathf.Pow(1.07f, DataManager.Instance.stageLvCount-1) );
        Power = (int)(LevelUpCost * 0.4);
        
    }

    private void Start() {
        StartCoroutine("TouchTime");
    }


    public void Attack()
    {
        if(colTime)
        {
            FindObjectOfType<StageManager>().enemyList[0].GetComponent<Enemy>().getDamage(Power);
        }
        
        

    }
    
    IEnumerator TouchTime()
    {
        while(true)
        {
            colTime = true;
            yield return new WaitForSeconds(0.1f);
            colTime = false;
            yield return new WaitForSeconds(0.1f);
            colTime = true;
            
        }
        
    }

    public void LevelUp()
    {
        if(DataManager.Instance.gold > 0)
        {
            DataManager.Instance.gold -= (int)LevelUpCost;
            DataManager.Instance.stageLvCount++;

        }
    }
}

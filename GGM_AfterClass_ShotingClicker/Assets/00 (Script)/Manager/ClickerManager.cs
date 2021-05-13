using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerManager : MonoBehaviour
{
    private float nextTime;
    public GameObject exploit;

    private void Start() 
    {

    }
    
    private void Update() 
    {
        DataManager.Instance.levelUpCost = (int)(50 * (Mathf.Pow(1.07f, DataManager.Instance.level-1) ));
        DataManager.Instance.power = (int)(DataManager.Instance.levelUpCost * 0.4);
    }

    public void Attack()
    {
        if (Time.time >= nextTime)
        {
            nextTime = Time.time + 0.1f;
            Debug.Log("클릭됨");
            FindObjectOfType<SpawnManager>().enemyList[0].GetComponent<Enemy>().getDamage(DataManager.Instance.power);
            GameObject ex = Instantiate(exploit, FindObjectOfType<SpawnManager>().enemyList[0].transform.position + new Vector3(-0.8f,  0, 0), Quaternion.identity);
            Destroy(ex, 0.2f);
        }
    }
    
    public void LevelUp()
    {
        if((float)DataManager.Instance.gold > DataManager.Instance.levelUpCost)
        {
            DataManager.Instance.gold -= (int)DataManager.Instance.levelUpCost;
            DataManager.Instance.level++;
        }
    }
}

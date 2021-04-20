using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public GameObject Enemy01;
    public int enemyHp;
    public int killReward;

    public float speed = 5.0f;
    private void Awake() 
    {
        killReward = (int)(10 * Mathf.Pow(1.06f, 10) - Mathf.Pow(1.06f, (10 + DataManager.Instance.stageLvCount)) / (1 - 1.06));
        enemyHp = killReward * 2;
    }
    
    private void Update() 
    {
        transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        //Debug.Log(killReward);
        Debug.Log(enemyHp);
    }

    public void getDamage(int damage)
    {
        enemyHp -= damage;

        if(enemyHp <= 0) 
        {
            FindObjectOfType<StageManager>().DestroyEnemy(this);
            Destroy(this.gameObject);
            DataManager.Instance.gold += killReward;
            DataManager.Instance.enemyCount++;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float enemyHp;

    private Hpslider hpslider;

    private void Awake() 
    {
        DataManager.Instance.killReward = (int)(10 * Mathf.Pow(1.06f, 10) - Mathf.Pow(1.06f, (10 + DataManager.Instance.stageLvCount)) / (1 - 1.06));
        enemyHp = DataManager.Instance.killReward * 2;
        hpslider = GameObject.Find("Enemy").GetComponent<Hpslider>();
    }
    
    private void Update() 
    {
        transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
    }

    public void getDamage(int damage)
    {
        enemyHp -= damage;

        if(enemyHp <= 0) 
        {
            Destroy(hpslider._hpPrefabs);
            Destroy(this.gameObject);
            FindObjectOfType<SpawnManager>().DestroyEnemy(this);
            DataManager.Instance.gold += DataManager.Instance.killReward;
            DataManager.Instance.enemykillcount++;
        }
    }
}

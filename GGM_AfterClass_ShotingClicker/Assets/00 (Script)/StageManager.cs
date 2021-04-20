using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
     
    
    int totalEnemy;
    public List<GameObject> enemyList = new List<GameObject>();
    
    // Start is called before the first frame update

    void Start()
    {
        StartCoroutine("Fire");
    }
    

    // Update is called once per frame
    void Update()
    {
        if(DataManager.Instance.enemyCount >= 10)
        {
            DataManager.Instance.stageLvCount++;
            DataManager.Instance.enemyCount = 0;
            totalEnemy = 0;
        }
    }

    
    IEnumerator Fire()
    {
        while (true)
        {
            if(enemyList.Count < 5 && totalEnemy < 10)
            {
                float randomY = Random.Range(3.0f, -3.0f);
                GameObject enemy = Instantiate(GetComponent<Enemy>().Enemy01, new Vector3(10f, randomY, 0f), Quaternion.identity);
                enemyList.Add(enemy);
                
                totalEnemy++;
            }
            
            yield return new WaitForSeconds(0.5f);
        }

    }

    public void DestroyEnemy(Enemy _enemy)
    {
        enemyList.Remove(_enemy.gameObject);
    }
}


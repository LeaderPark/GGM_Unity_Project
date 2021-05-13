using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float spawntime = 0.5f;
    
    public GameObject enemy = null;

    public List<GameObject> enemyList = new List<GameObject>();
    
    private void Start() 
    {
        StartCoroutine("EnemySpawn");
    }
    
    IEnumerator EnemySpawn()
    {
        while (true)
        {
            if(enemyList.Count < DataManager.Instance.enemymax && DataManager.Instance.totalEnemy < 16)
            {
                float randomY = Random.Range(4f, -4f);
                GameObject _enemy = Instantiate(enemy, new Vector3(10f, randomY, 0f), Quaternion.identity);
                enemyList.Add(_enemy);
                
                DataManager.Instance.totalEnemy++;
            }
            
            yield return new WaitForSeconds(spawntime);
        }
    }

    public void DestroyEnemy(Enemy _enemy)
    {
        enemyList.Remove(_enemy.gameObject);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemy;
    public GameObject EndCube;

    public List<EnemyBehavior> EnemyList = new List<EnemyBehavior>();

    // Update is called once per frame

    public int enemyCount;
    void Start()
    {
        StartCoroutine(CreateEnemy());
        enemyCount = 0;
    }

    

    public IEnumerator CreateEnemy()
    {
        while (true)
        {
            EnemyList.Add(Instantiate(enemy, new Vector3(8f, Random.Range(-5f, 5f), 0f), Quaternion.identity).GetComponent<EnemyBehavior>());
            yield return new WaitForSeconds(1f);
        }
    }

    public void DestroyEnemy()
    {

    }
}

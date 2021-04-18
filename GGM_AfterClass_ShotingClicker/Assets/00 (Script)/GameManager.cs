using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Enemy01;

    List<GameObject> enemyList = new List<GameObject>();
    
    // Start is called before the first frame update

    void Start()
    {
        StartCoroutine("Fire");
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Fire()
    {
        while (true)
        {
            float randomY = Random.Range(3.0f, -3.0f);
            GameObject enemy = Instantiate(Enemy01, new Vector3(10f, randomY, 0f), Quaternion.identity);
            enemyList.Add(enemy);


            yield return new WaitForSeconds(0.7f);
        }

    }
}

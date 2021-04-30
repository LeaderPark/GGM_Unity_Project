using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class StageManager : MonoBehaviour
{
    int totalEnemy;
    Light2D light2D;

    public List<GameObject> enemyList = new List<GameObject>();
    
    // Start is called before the first frame update

    void Start()
    {

        StartCoroutine("Fire");
        light2D = GameObject.Find("PointLight2D").GetComponent<Light2D>(); 
    }
    

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("lightin");
        if(DataManager.Instance.enemyCount >= 10)
        {
            DataManager.Instance.enemyCount = 0;
            totalEnemy = 0;
            DataManager.Instance.stageLvCount++;
            StartCoroutine("lightout");
            StartCoroutine("lightin");

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

    IEnumerator lightin()
    {
        light2D.pointLightOuterRadius = Mathf.Lerp(light2D.pointLightOuterRadius, 10f, 0.5f *Time.deltaTime);
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator lightout()
    {
        light2D.pointLightOuterRadius = Mathf.Lerp(light2D.pointLightOuterRadius, 0f, 0.5f *Time.deltaTime);
        light2D.color = Random.ColorHSV();
        yield return new WaitForSeconds(0.5f);

    }
}


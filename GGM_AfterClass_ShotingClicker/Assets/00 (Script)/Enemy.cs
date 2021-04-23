using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    
    public GameObject Enemy01;
    public int enemyHp;
    public int killReward;

    public float speed = 5.0f;

    public Slider HpSlider;

    public GameObject hpPrefabs1;
    public GameObject hpPrefabs;
    private Canvas canvas;
  
    private void Awake() 
    {
        killReward = (int)(10 * Mathf.Pow(1.06f, 10) - Mathf.Pow(1.06f, (10 + DataManager.Instance.stageLvCount)) / (1 - 1.06));
        enemyHp = killReward * 2;
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        hpPrefabs1 = Instantiate(hpPrefabs, canvas.transform);
        HpSlider = hpPrefabs1.GetComponent<Slider>();
    }
    
    private void Update() 
    {
        transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        //Debug.Log(killReward);
        Vector3 sliderpos = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x ,transform.position.y + 1f, 0));
        HpSlider.transform.position = sliderpos;
    }

    public void getDamage(int damage)
    {
        enemyHp -= damage;

        if(enemyHp <= 0) 
        {
            FindObjectOfType<StageManager>().DestroyEnemy(this);
            Destroy(this.hpPrefabs1);
            Destroy(this.gameObject);
            DataManager.Instance.gold += killReward;
            DataManager.Instance.enemyCount++;
        }
    }
}

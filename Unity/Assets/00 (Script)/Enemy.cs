using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed;

    public Slider HpSlider;

    public GameObject hpPrefabs1;
    public GameObject hpPrefabs;
    public Canvas canvas;
  
    private void Awake() 
    {
        DataManager.Instance.killReward = (int)(10 * Mathf.Pow(1.06f, 10) - Mathf.Pow(1.06f, (10 + DataManager.Instance.stageLvCount)) / (1 - 1.06));
        DataManager.Instance.enemyHp = DataManager.Instance.killReward * 2;
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        hpPrefabs1 = Instantiate(hpPrefabs, canvas.transform);
        HpSlider = hpPrefabs1.GetComponent<Slider>();
    }
    
    private void Update() 
    {
        speed = Random.Range(3, 5);
        transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        Vector3 sliderpos = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x ,transform.position.y + 1f, 0));
        HpSlider.transform.position = sliderpos;
    }

    public void getDamage(int damage)
    {
        DataManager.Instance.enemyHp -= damage;

        if(DataManager.Instance.enemyHp <= 0) 
        {
            FindObjectOfType<SpawnManager>().DestroyEnemy(this);
            Destroy(this.hpPrefabs1);
            Destroy(this.gameObject);
            DataManager.Instance.gold += DataManager.Instance.killReward;
            DataManager.Instance.enemykillcount++;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Enemy enemy;

    private void Start() {
        enemy = GameObject.Find("SpawnManger").GetComponent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Enemy")
        {
            StartCoroutine("Respawn");
        }
    }

    IEnumerator Respawn()
    {
        Destroy(enemy.hpPrefabs1);
        Destroy(this.gameObject);
        SceneManager.LoadScene("Game");
        DataManager.Instance.stageLvCount = 1;
        DataManager.Instance.totalEnemy = 0;
        DataManager.Instance.enemykillcount = 0;
        yield return null;
    }
}

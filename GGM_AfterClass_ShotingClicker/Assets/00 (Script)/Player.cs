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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            StartCoroutine("Respawn");
        }
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(0f);
        Destroy(enemy.hpPrefabs1);
        Destroy(this.gameObject);
        SceneManager.LoadScene("Game");
        DataManager.Instance.stageLvCount = 1;
        DataManager.Instance.count = 0;
        DataManager.Instance.enemyCount = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateScript : MonoBehaviour
{
    public GameObject brokenPrefab; 

    private Rigidbody2D rigid;

    static public int cratecount = 20;

    private void Update() 
    {
        if(transform.position.y <= -10)
        {
            Destroy(this.gameObject);
            cratecount--;
        }
    }
    
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    
    public void AddExplosion(Vector3 pos, float power){
        Vector3 dir = transform.position - pos; 
        //폭탄의 위치를 내위치에서 뺀다.
        rigid.AddForce(dir.normalized * power, ForceMode2D.Impulse);
        power *= 1/dir.sqrMagnitude;

        //rigid.AddForce(dir.normalized * power, ForceMode2D.Impulse);
        GameObject broken = Instantiate(brokenPrefab, transform.position, transform.rotation);

        BrokenScript bs = broken.GetComponent<BrokenScript>();
        bs.AddExplosion(dir.normalized, power);

        Destroy(gameObject);
        Destroy(broken, 2f);
    }
    
}
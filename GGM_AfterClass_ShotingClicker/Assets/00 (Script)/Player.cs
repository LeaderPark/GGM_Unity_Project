using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject Bullet;
    public Transform bulletPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine("Fire");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // IEnumerator Fire()
    // {
    //     while (true)
    //     {
    //         GameObject bullet = Instantiate(Bullet, bulletPosition.transform.position, Quaternion.identity) ;
    //         yield return new WaitForSeconds(1f);
    //     }
    // }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {

            //  StartCoroutine("ReloadScene");
            
        }
    }

    IEnumerator ReloadScene()
    {

        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("SampleScene");

        
    }
}

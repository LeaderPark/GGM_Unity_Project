using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QBox : MonoBehaviour // ����ǥ �ڽ�, �ٽ� �� ���� ��������Ʈ 1,2 �� ������Ʈ ���� ������ ���ϰ� �־��ָ� ��.
{
    public GameObject playerHead;
    public GameObject sprite_1;
    public GameObject sprite_2;
    void Start()
    {
        playerHead = GameObject.Find("PlayerHead");
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y - playerHead.transform.position.y < 0.1f)
        {
            sprite_1.SetActive(false);
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QBox : MonoBehaviour // 물음표 박스, 다시 할 때는 스프라이트 1,2 에 오브젝트 뭐로 넣을지 정하고 넣어주면 됌.
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

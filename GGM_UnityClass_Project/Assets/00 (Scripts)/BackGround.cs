using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] 
    Transform[] Background = null;
    [SerializeField]
    float speed = 0f;

    float leftPosX = 0f;
    float RightPosX = 0f;

    void Start()
    {
        float length = Background[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        leftPosX = -length;
        RightPosX = length * Background.Length;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i<Background.Length; i++)
        {
            Background[i].position +=  new Vector3(speed, 0, 0) * Time.deltaTime;

            if(Background[i].position.x < leftPosX)
            {
                Vector3 selfPos = Background[i].position;
                selfPos.Set(selfPos.x + RightPosX, selfPos.y, selfPos.z);
                Background[i].position = selfPos;

            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    float trCheck;

    // Update is called once per frame
    void Update()
    {
        //trCheck += speed * Time.deltaTime;
        //if (trCheck > 3.5f || trCheck < -3.5f)
        //{
        //    speed *= -1;
        //}
        //transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
    }
}

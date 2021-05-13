using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float rollingSpeed = 0f;
    public bool breaking = false;
    public float speed = 0f;
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, 0, rollingSpeed * Time.deltaTime); 

        if(Input.GetMouseButtonDown(0))
        {
            speed = 100f;
            rollingSpeed = 400f;
            breaking = false;
            
        }
        if(Input.GetMouseButtonUp(0))
        {
            breaking = true;
        }

        if(breaking)
        {
            speed -= speed * 0.8f * Time.deltaTime;
            rollingSpeed -= 0.8f * rollingSpeed * Time.deltaTime;
            if(speed <= 0.1f)
            {
                speed = 0;
                rollingSpeed = 0;
                breaking = false;
            }
        }
    }
}

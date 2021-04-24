using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carparent : MonoBehaviour
{
    public float speed = 0f;
    public bool breaking = false;
    private void Update() {
        transform.Translate(new Vector2(speed * Time.deltaTime, 0));

        if(Input.GetMouseButtonDown(0))
        {
            speed = 5f;
            breaking = false;
            
        }
        if(Input.GetMouseButtonUp(0))
        {
            breaking = true;
        }

        if(breaking)
        {
            speed -= speed * 0.8f * Time.deltaTime;
            if(speed <= 0.1f)
            {
                speed = 0;
                breaking = false;
            }
        }
    }

    
}

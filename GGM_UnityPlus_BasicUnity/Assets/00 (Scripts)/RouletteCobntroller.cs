using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteCobntroller : MonoBehaviour
{
   private float rollingSpeed = 0f;
    private bool on = false;

    private void Start() 
    {
        //Generic Type
        // Transform t = GetComponent<Transform>(); 
        // t.localScale *= 2;                   
    }

    private void Update() 
    {
        Debug.Log(rollingSpeed);
        Debug.Log(on);
        // if(rollingSpeed >= 1000f)
        // {
        //     on = true;
        // }
        
        if(!on)
        {
            rollingSpeed -= 0.5f * rollingSpeed * Time.deltaTime;
        }
        else
        {
            rollingSpeed += 0.5f * rollingSpeed * Time.deltaTime;
        }

        if(Input.GetMouseButtonDown(0))
        {
            if(on){
                on = false;
            }
            else{
                rollingSpeed = 360;
                on = true;
            }
        }

        gameObject.transform.Rotate(0, 0, rollingSpeed * Time.deltaTime); 
        
    }
}

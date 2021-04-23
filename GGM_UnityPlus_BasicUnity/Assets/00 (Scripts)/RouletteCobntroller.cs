using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteCobntroller : MonoBehaviour
{
    public float rollingSpeed = 0f;
    private bool on = true;

    private void Start() 
    {
        //Generic Type
        // Transform t = GetComponent<Transform>(); 
        // t.localScale *= 2;                   
    }

    private void Update() 
    {
        if(Input.GetMouseButton(0))
        {
            // if(on)
            // {
            //     gameObject.transform.localScale *= 2;
            //     on = false;
            // }
            // else
            // {
            //     gameObject.transform.localScale /= 2;   
            //     on = true;
            //}
            // on = !on; //누를때마다 on의 값을 바꿔줌

            rollingSpeed = 360;
        }
            gameObject.transform.Rotate(0, 0, rollingSpeed * Time.deltaTime); 
    }
}

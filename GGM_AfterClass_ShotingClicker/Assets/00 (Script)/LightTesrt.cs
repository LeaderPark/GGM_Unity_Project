using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightTesrt : MonoBehaviour
{
    Light2D mylight;
    // Start is called before the first frame update
    void Start()
    {
        mylight = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mylight.color = Random.ColorHSV();
        mylight.pointLightInnerRadius = Mathf.Lerp(mylight.pointLightInnerRadius, 10f, Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrameCounter : MonoBehaviour
{
    public Text textobj;
    public float frame = 0;
    public float second = 0;

    // Update is called once per frame
    void Update()
    {
        frame++;
        second += Time.deltaTime;
        
        if(second >= 1)
        {
            textobj.text = $"{frame} FPS";
            frame = 0;
            second = 0;
        }
    }
}

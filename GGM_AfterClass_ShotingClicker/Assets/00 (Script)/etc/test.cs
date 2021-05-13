using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    SpriteRenderer sprite;
    ShaderTest outline;

    private void Start() {
        outline = GetComponent<ShaderTest>();
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Update() {
        if(Input.GetMouseButtonDown(0))
        {
            sprite.color = new Color(Random.value, Random.value, Random.value, 1f);
            outline.color = new Color(Random.value, Random.value, Random.value, 1f);
            outline.outlineSize = Random.Range(1,12);
        }
        else if(Input.GetMouseButtonUp(0))
        {
            sprite.color = new Color(255, 255, 255, 1f);
            outline.outlineSize = 0;
        }
    }
}

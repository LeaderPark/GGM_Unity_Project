using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private void OnParticleCollision(GameObject other) 
    {
        Debug.Log("레이저에 맞았다 : " + other.gameObject.name);
    }
}

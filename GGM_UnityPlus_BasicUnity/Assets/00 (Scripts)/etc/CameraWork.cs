using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWork : MonoBehaviour
{
    public float minX = 0;
    public float maxX = 25f;

    public float moveSpeed = 4f;

    void Update() 
    {
        // 입력에서 좌우 입력값을 Raw값으로 받아옴 ( -1, 0, 1)
        float x = Input.GetAxisRaw("Horizontal");

        Vector3 nextPost = transform.position + new Vector3(x * moveSpeed * Time.deltaTime, 0, 0);

        nextPost.x = Mathf.Clamp(nextPost.x, minX, maxX);

        transform.position = nextPost;
    }

}

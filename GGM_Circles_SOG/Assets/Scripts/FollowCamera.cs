using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject player;
    Vector3 target;


    void LateUpdate()
    {
        transform.position = target; // 이 스크립트를 가진 오브젝트, 즉 카메라가 target의 위치로 이동합니다.

        target = new Vector3(                // 타겟의 위치 = 플레이어의 위치
            player.transform.position.x,     // 플레이어의 x좌표
            player.transform.position.y,
            player.transform.position.z-10);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject player;
    Vector3 target;


    void LateUpdate()
    {
        transform.position = target; // �� ��ũ��Ʈ�� ���� ������Ʈ, �� ī�޶� target�� ��ġ�� �̵��մϴ�.

        target = new Vector3(                // Ÿ���� ��ġ = �÷��̾��� ��ġ
            player.transform.position.x,     // �÷��̾��� x��ǥ
            player.transform.position.y,
            player.transform.position.z-10);
    }
}

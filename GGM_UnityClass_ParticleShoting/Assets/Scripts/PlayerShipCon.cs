using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipCon : MonoBehaviour
{
    [SerializeField] float controlSpeed = 25f;
    [SerializeField] float xLimitRange = 7f;
    [SerializeField] float yLimitRange = 7f;

    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float positionYawFactor = 2f;
    [SerializeField] float controlRollFactor = -20f;
    [SerializeField] GameObject[] laserObjs; 

    float xAxisVal, yAxisVal;

    void Update()
    {
        Move();
        rotate();
        ProcessFire();
    }

    private void rotate()
    {
        // 회전 관련 코드
        float pitchDueToPos = transform.localPosition.y * positionPitchFactor;
        float pitchDueToCotrolAxis = yAxisVal * controlPitchFactor;

        float pitch = pitchDueToPos + pitchDueToCotrolAxis;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xAxisVal * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void Move()
    {
        // 이동 관련 코드
        xAxisVal = Input.GetAxis("Horizontal");
        yAxisVal = Input.GetAxis("Vertical");

        float xOffset = xAxisVal * Time.deltaTime * controlSpeed;
        float xPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(xPos, -xLimitRange, xLimitRange);

        float yOffset = yAxisVal * Time.deltaTime * controlSpeed;
        float yPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(yPos, -yLimitRange, yLimitRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessFire()
    {
        if(Input.GetButton("Fire1"))
        {
            //레이저를 켠다
            setLaserActive(true);
        }
        else
        {
            //레이저를 끈다
            setLaserActive(false);
        }
    }

    void setLaserActive(bool isActive)
    {
        foreach(GameObject laser in laserObjs)
        {
            // laser.SetActive(isActive);

            var emissionVal = laser.GetComponent<ParticleSystem>().emission;
            emissionVal.enabled = isActive;
        }
    }
}

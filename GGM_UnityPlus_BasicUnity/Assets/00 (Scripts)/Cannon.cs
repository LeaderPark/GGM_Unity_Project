using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class Cannon : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform firePos;
    public float maxPower = 1000f; 
    public float chargingPower = 200f;
    public float power = 0;
    
    static public int ballcount = 10;

    public Text angleText;
    public Text powerText;
    public Image powerGauge;

    public float angleSpeed = 60f; //초당 60도 회전

    public CinemachineVirtualCamera cannonCam;
    public CinemachineBrain mainCam;

    public ParticleSystem muzzleFlash;

    static public bool reload = true;

    void Update()
    {
        // transform.Rotate(new Vector3(0,0, angleSpeed * Time.deltaTime));

        //위에 키가 눌리는 동안
        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(new Vector3(0,0, angleSpeed * Time.deltaTime));
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(new Vector3(0,0, -angleSpeed * Time.deltaTime));
        }

        float z = Mathf.Clamp(transform.rotation.eulerAngles.z, 1, 88);
        transform.rotation = Quaternion.Euler(0, 0, z);

        if(reload && ballcount != 0)
        {
            if(Input.GetMouseButtonDown(0))
            {
                power = 0;
            }
            else if(Input.GetMouseButton(0))
            {  
                power += chargingPower * Time.deltaTime * 2;
                power = Mathf.Clamp(power, 0, maxPower);    
            }
            else if(Input.GetMouseButtonUp(0))
            {
                Fire();
                reload = false;
            }
        }


        angleText.text = $"{z.ToString("N0")}º";
        powerText.text = power.ToString("N0");
        powerGauge.fillAmount = power / maxPower;
    }

    private void Fire()
    {
        StartCoroutine(DelayFire());
        ballcount--; 
    }

    IEnumerator DelayFire()
    {
        mainCam.m_DefaultBlend.m_Time = 1f;
        Vector3 next = firePos.position;
        next.z = cannonCam.transform.position.z;
        cannonCam.transform.position = next;

        cannonCam.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);

        GameObject ball = Instantiate(ballPrefab, firePos.position, Quaternion.identity);
        CannonBallScript bs = ball.GetComponent<CannonBallScript>();
        bs.Shoot( firePos.right, power, cannonCam);

        muzzleFlash.Play();

        cannonCam.Follow = ball.transform;
    }
}
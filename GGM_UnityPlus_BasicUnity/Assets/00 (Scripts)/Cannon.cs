using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cannon : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform firePos;
    public float power = 0;
    public float chargeingPower = 200f;
    public Text powerUI;
    public Text angleUI;
    public Slider slider;
    public bool isuppower = true;

    public float angleSpeed = 60f;

    void Update()
    {
        float z = Mathf.Clamp(transform.rotation.eulerAngles.z, 1, 88);
        transform.rotation = Quaternion.Euler(0, 0, z);
        
        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(new Vector3(0,0, angleSpeed * Time.deltaTime));
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(new Vector3(0,0, -angleSpeed * Time.deltaTime));
        }


        if(Input.GetMouseButtonDown(0))
        {
            power = 0;
            slider.value = 0;
        }
        else if(Input.GetMouseButton(0))
        {
            power += chargeingPower * Time.deltaTime;
            power = Mathf.Clamp(power, 0, 1000);
        }
        else if(Input.GetMouseButtonUp(0))
        {
            Fire();
        }

        angleUI.text = $"{z}º";
        powerUI.text = power.ToString("N0");
        slider.value = power;
    }



    private void Fire()
    {
        GameObject ball = Instantiate(ballPrefab, firePos.position, Quaternion.identity);
        cannonball bs = ball.GetComponent<cannonball>();
        bs.Shoot(firePos.right, power);
        Destroy(ball, 2f);
    }
}
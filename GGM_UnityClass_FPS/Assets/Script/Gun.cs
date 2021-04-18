using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public float power = 10f;
    public float range = 100f;
    public Camera fpsCam;

    //파티클&물리 관련 변수 선언
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public float impactForce = 60f;

    //레이져와 십자선 관련 변수
    public LineRenderer lineLaser;
    public GameObject crosshair;

    //연사모드를 위한 변수
    public float firelate = 3f;
    private float nextTimeToFire = 0f;

    //리로드 
    public Image reloadImg;
    bool isReload = false;
    float reloadCurrentTime = 0f;
    float reloadMaxTime = 0f;

    void Update()
    {        
        crosshair.SetActive(true);
        //라인랜더러 처리 
        RaycastHit laserHit;
        Ray laserRay = new Ray(lineLaser.transform.position, lineLaser.transform.forward);
        if(Physics.Raycast(laserRay, out laserHit))
        {
            // 라인랜더러의 끝점 위치를 맞춰준다. 
            lineLaser.SetPosition(1, lineLaser.transform.InverseTransformPoint(laserHit.point));

            // 조준점을 라인랜더러의 위치에 동기화 시켜줌
            Vector3 crosshairLocation = Camera.main.WorldToScreenPoint(laserHit.point);
            crosshair.transform.position = crosshairLocation;
        }
        else
        {
            crosshair.SetActive(false); //레이래스트가 hit이 안될떄는 crosshair를 끈다. 
        }

        // 단발 발사 
        // if(Input.GetButtonDown("Fire1"))
        // {
        //     Shoot();
        // }

        if(Input.GetButton("Fire1") && Time.time > nextTimeToFire)
        {
            nextTimeToFire = Time.time + (1/firelate);
            Shoot();

            //isRelaod True;
            reloadMaxTime = nextTimeToFire - Time.time;
            reloadCurrentTime = 0f;
            isReload = true;
        }

        //리로드 게이지 처리
        if(isReload)
        {
            reloadCurrentTime += Time.deltaTime;
            reloadImg.fillAmount = reloadCurrentTime / reloadMaxTime;
            if(reloadImg.fillAmount >= 1f)
            {
                reloadImg.fillAmount = 0f;
                isReload = false;
            }
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if(Physics.Raycast(lineLaser.transform.position, //카메라 위치에서
                           lineLaser.transform.forward,  //카메라 전방으로
                           out hit, range))
        {
            // Debug.Log(hit.transform.name);
            TargetBox tb = hit.transform.GetComponent<TargetBox>();
            if(tb != null)
            {
                tb.TakeDamage(power);
            }

            //박스 밀림 처리
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce); //normal = 힘은 다빼고 방향만 가져오기
            }
            //파티클 생성
            GameObject impactObj =  Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactObj, 1f);
        }
    }
}

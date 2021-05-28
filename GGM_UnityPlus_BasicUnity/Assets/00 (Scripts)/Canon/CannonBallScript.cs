using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CannonBallScript : MonoBehaviour
{
    public LayerMask whatIsTarget;  // 땅, 상자에
    public float expRadius = 2f;        // 폭발 반경   
    public float expPower = 1000f;      // 폭발     힘
    private Rigidbody2D rigid;
    
    private int crateLayer; // 상자레이어

    private CinemachineVirtualCamera cannonCam;

    public GameObject muzzleFlash;

    //Awake -> Enable -> Start
    void Awake() 
    {
        rigid = GetComponent<Rigidbody2D>();
        crateLayer = LayerMask.NameToLayer("CRATE");
        // CRATE라는 이름의 레이어의 번호가 넘어옴
    }

    private void Update() 
    {
        if(transform.position.y <= -10)
        {
            cannonCam.gameObject.GetComponent<CameraManager>().SetDisable(1.5f);
            Destroy(this.gameObject);
            Cannon.reload = true;
        }
    }
    
    public void Shoot(Vector2 direction, float power, CinemachineVirtualCamera cam)
    {
        cannonCam = cam;
        rigid.AddForce(direction * power);
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        int layer = collisionInfo.gameObject.layer;

        if( ((1 << layer) & whatIsTarget) > 0)
        {
            Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, expRadius, 1 << crateLayer);
            if(cols.Length >= 1)
            { //반경내에 한개 이상 있다면
                foreach(Collider2D c in cols){ 
                    //각각의 상자를 c라 놓고 작업
                    CrateScript cs = c.gameObject.GetComponent<CrateScript>();
                    if(cs != null)
                    {
                        cs.AddExplosion(transform.position, expPower);
                        CrateScript.cratecount--;
                    }
                }
            }   //충돌이 한개 이상 끝
            Instantiate(muzzleFlash, transform.position, Quaternion.identity);
            Instantiate(muzzleFlash, transform.position, Quaternion.identity);
            Instantiate(muzzleFlash, transform.position, Quaternion.identity);
            Instantiate(muzzleFlash, transform.position, Quaternion.identity);
            Instantiate(muzzleFlash, transform.position, Quaternion.identity);

            cannonCam.gameObject.GetComponent<CameraManager>().SetDisable(1.5f);
            Destroy(this.gameObject);
            Cannon.reload = true;
        }   // 레이어안에 충돌 존재
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Ready,
    Empty,
    Reloading
}

public class Gun : MonoBehaviour
{
    public State state { get; private set; }
    public Transform firePosition;
    public ParticleSystem muzzleEffect; // 총구화염 이펙트
    public ParticleSystem shellEjectEffect; //탄피배출 이펙트
    public float bulletLineEffectTime = 0.03f; //라인이 그려지는 시간

    public LineRenderer bulletLineRenderer; //총알 라인렌더러
    public float damage = 25f; //총알의 데미지
    public float fireDistance = 50f; //사거리
    public int magCapacity = 10; //탄창의 용량
    public int magAmmo = 10; //현재 장전된 총알 수
    public float timeBetFire = 0.12f; //탄알 발사 간격
    public float reloadTime = 1.0f; // 재장전 시간
    public float lastFireTime; // 총을 마지막으로 발사한 시간

    private void Start()
    {
        magAmmo = magCapacity;
        state = State.Ready;
        lastFireTime = 0;
    }

    public void Fire()
    {
        //외부에서 총에다가 공격명령을 내리면
        //조건이 맞으면 Shot을 실행한다.
        if(state == State.Ready && Time.time >= lastFireTime + timeBetFire)
        {
            Shot();
        }
    }

    private void Shot()
    {
        //실제 공격은 여기서 이루어진다.

        RaycastHit hit;
        Vector3 hitPosition = Vector3.zero;
        if(Physics.Raycast(
            firePosition.position, 
            firePosition.forward,
            out hit,
            fireDistance))
        {
            IDamageable target = hit.transform.GetComponent<IDamageable>();
            if(target != null)
            {
                target.OnDamage(damage, hit.point, hit.normal);
            }
            hitPosition = hit.point;
        }else
        {
            hitPosition = firePosition.position
                        + firePosition.forward * fireDistance;
        }

        StartCoroutine(ShotEffect(hitPosition));
        magAmmo--;
        if(magAmmo <= 0)
        {
            state = State.Empty;
        }
    }

    private IEnumerator ShotEffect(Vector3 hitPosition)
    {
        muzzleEffect.Play();
        shellEjectEffect.Play();
        //hitposition 월드 좌표
        bulletLineRenderer.SetPosition( 1, 
            bulletLineRenderer.transform.InverseTransformPoint(hitPosition)
        );

        bulletLineRenderer.gameObject.SetActive(true);
        yield return new WaitForSeconds(bulletLineEffectTime);
        bulletLineRenderer.gameObject.SetActive(false);
    }

    public bool Reload()
    {
        if(state == State.Reloading || magAmmo >= magCapacity)
        {
            return false;
        }
        StartCoroutine(ReloadRoutine());
        return true;
    }

    private IEnumerator ReloadRoutine()
    {
        state = State.Reloading;
        yield return new WaitForSeconds(reloadTime);
        magAmmo = magCapacity;
        state = State.Ready;
    }

}
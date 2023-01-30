using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRandomTargetingProjectile : Weaphone
{
    /// <summary>
    /// 랜덤한 타겟으로 투사체를 날리는 무기
    /// </summary>
    protected override void Start()
    {
        base.Start();
        //투사체 개수
        SetProjectileNum(1);
        //투사체 속도
        SetSpeed(100.0f);
        //공격 쿨다운
        SetCoolDown(1.0f);
    }

    public override void Attack()
    {
        //랜덤한 타겟 Transform 가져오기
        Transform target = transform.parent.GetComponent<WeaponCenter>().GetRandomTarget();
        if (projectile == null)
            return;
        if (target == null)
            return;
        //타겟 vector 계산 (y 1을 더해야 타겟의 가운데)
        Vector3 targetPos = target.position + new Vector3(0, 1, 0);

        //투사체 생성
        GameObject ProjectileObject = Instantiate(projectile, transform);
        //투사체 부모 오브젝트 제거
        ProjectileObject.transform.parent = null;
        ProjectileObject.SetActive(true);

        //투사체 지속 시간 설정
        ProjectileObject.GetComponent<Projectile>().SetDuration(2.0f);
        //투사체 타겟 방향으로 각도 설정
        ProjectileObject.transform.Rotate(new Vector3(0, 0, Quaternion.FromToRotation(Vector3.up, targetPos - transform.position).eulerAngles.z));
        //투사체 타겟 방향으로 이동
        ProjectileObject.GetComponent<Rigidbody2D>().AddForce((targetPos - transform.position).normalized * 10 * speed);
    }

}

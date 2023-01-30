using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLazorUpgrade : Weaphone
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
        SetCoolDown(10.0f);
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
        GameObject ProjectileObject = Instantiate(projectile, target);
        ProjectileObject.SetActive(true);

        //투사체 지속 시간 설정
        ProjectileObject.GetComponent<Projectile>().SetDuration(8.0f);
        
    }

}

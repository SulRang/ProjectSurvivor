using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCannonUpgrade : Weaphone
{
    /// <summary>
    /// 랜덤한 타겟으로 투사체를 소환하는 무기
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
    public void LevelUp()
    {
        level++;
        SetCoolDown(10.0f - level);
    }

    public override void Attack()
    {
        if (projectile == null)
            return;

        //투사체 생성
        GameObject ProjectileObject = Instantiate(projectile, transform);
        //투사체 부모 오브젝트 제거
        ProjectileObject.transform.parent = null;
        ProjectileObject.SetActive(true);
        //투사체 지속 시간 설정
        ProjectileObject.GetComponent<Projectile>().SetDuration(10f);
    }
}

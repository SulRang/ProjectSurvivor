using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFireBallUpgrade : Weaphone
{
    [SerializeField]
    int level = 1;
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
        SetCoolDown(5.0f);
    }
    public void LevelUp()
    {
        level++;
    }

    public override void Attack()
    {
        if (projectile == null)
            return;
        GameObject ProjectileObject;
        for (int i = 0; i < projectileNum + level/2; i++)
        {
            //랜덤한 타겟 Transform 가져오기
            Transform target = transform.parent.GetComponent<WeaponCenter>().GetRandomTarget();
            if (target == null)
                return;
            //타겟 vector 계산 (y 1을 더해야 타겟의 가운데)
            Vector3 targetPos = target.position + new Vector3(0, 0.5f, 0);
            ProjectileObject = Instantiate(projectile, target);
            //투사체 부모 오브젝트 제거
            ProjectileObject.transform.parent = null;
            ProjectileObject.SetActive(true);
            ProjectileObject.GetComponent<Projectile>().SetDuration(12.0f);
            ProjectileObject.transform.position += new Vector3(12.0f, 12.0f);
        }
    }
}

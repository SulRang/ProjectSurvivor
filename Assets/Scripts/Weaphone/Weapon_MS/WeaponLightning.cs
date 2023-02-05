using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLightning : Weaphone
{
    [SerializeField]
    bool isUpgrade = false;
    int level = 1;

    [SerializeField]
    GameObject upgradeProjectile;
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
        SetCoolDown(3.0f);
    }
    public void LevelUp()
    {
        level++;
        SetProjectileNum(level);
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
        Vector3 targetPos = target.position + new Vector3(0, 0.5f, 0);
        GameObject ProjectileObject;
        for (int i = 0; i < projectileNum; i++)
        {
            if (isUpgrade)
            {
                ProjectileObject = Instantiate(upgradeProjectile, transform);
                //투사체 부모 오브젝트 제거
                ProjectileObject.transform.parent = null;
                ProjectileObject.SetActive(true);
                ProjectileObject.GetComponent<Projectile>().SetDuration(2.0f);
                //투사체 타겟 방향으로 각도 설정
                ProjectileObject.transform.Rotate(new Vector3(0, 0, Quaternion.FromToRotation(Vector3.up, targetPos - transform.position).eulerAngles.z));
                //투사체 타겟 방향으로 이동
                ProjectileObject.GetComponent<Rigidbody2D>().AddForce((targetPos - transform.position).normalized * 10 * speed);
            }
            else
            {
                //투사체 생성
                ProjectileObject = Instantiate(projectile, target);
                //투사체 부모 오브젝트 제거
                ProjectileObject.transform.parent = null;
                ProjectileObject.SetActive(true);
                //투사체 지속 시간 설정
                ProjectileObject.GetComponent<Projectile>().SetDuration(1.5f);
            }
        }
    }
}

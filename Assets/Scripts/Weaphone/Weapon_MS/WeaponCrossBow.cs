using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCrossBow : Weaphone
{
    int level = 1;
    [SerializeField]
    bool isUpgrade = false;
    /// <summary>
    /// 가까운 타겟으로 투사체를 날리는 무기
    /// </summary>
    protected override void Start()
    {
        base.Start();
        //투사체 개수
        SetProjectileNum(1);
        //투사체 속도
        SetSpeed(100.0f);
        //공격 쿨다운
        SetCoolDown(8.0f / (level + 1));
    }

    public void LevelUp()
    {
        level++;
    }


    public override void Attack()
    {
        //가까운 타겟 Transform 가져오기
        Transform target = transform.parent.GetComponent<WeaponCenter>().GetCloseTarget();

        if (projectile == null)
            return;
        if (target == null)
            return;
        //타겟 vector 계산 (y 0.5f을 더해야 타겟의 가운데)
        Vector3 targetPos = target.position + new Vector3(0, 0.5f, 0);
        //플레이어 -> 타겟 벡터
        Vector3 difVec3 = targetPos - transform.position;

        //투사체 생성
        GameObject ProjectileObject = Instantiate(projectile, transform);
        //투사체 부모 오브젝트 제거
        ProjectileObject.transform.parent = null;
        ProjectileObject.SetActive(true);

        //투사체 지속 시간 설정
        ProjectileObject.GetComponent<Projectile>().SetDuration(2.0f);
        if (isUpgrade)
            ProjectileObject.GetComponent<CrossbowBoltProjectile>().Upgrade();
        //투사체 타겟 방향으로 각도 설정
        ProjectileObject.transform.Rotate(new Vector3(0, 0, Quaternion.FromToRotation(Vector3.up, difVec3).eulerAngles.z));
        //투사체 타겟 방향으로 이동
        ProjectileObject.GetComponent<Rigidbody2D>().AddForce(difVec3.normalized * 10 * speed);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSword : Weaphone
{
    [SerializeField]
    int level = 1;
    [SerializeField]
    bool isClass = false;
    [SerializeField]
    int classIdx = 8;

    /// <summary>
    /// 가까운 타겟으로 투사체를 날리는 무기
    /// </summary>
    protected override void Start()
    {
        base.Start();
        //투사체 개수
        SetProjectileNum(1);
        //투사체 속도
        SetSpeed(speed);
        //공격 쿨다운
        SetCoolDown(8.0f / (level));
    }

    public void LevelUp()
    {
        level++;
        SetCoolDown(8.0f / (level));
    }


    public override void Attack()
    {
        //가까운 타겟 Transform 가져오기
        Transform target = transform.parent.GetComponent<WeaponCenter>().GetCloseTarget();
        if (projectile == null)
            return;
        if (target == null)
            return;
        //타겟 vector 계산 (y 1을 더해야 타겟의 가운데)
        Vector3 targetPos = target.position + new Vector3(0, 0.5f, 0);

        //투사체 생성
        GameObject ProjectileObject = Instantiate(projectile, transform);
        ProjectileObject.SetActive(true);
        //투사체 지속 시간 설정
        ProjectileObject.GetComponent<Projectile>().SetDuration(0.5f);
        ProjectileObject.GetComponent<Projectile>().SetSize(1 + level / 2);

        //투사체 타겟 방향으로 각도 설정
        float angle = Quaternion.FromToRotation(Vector3.up, targetPos - transform.position).eulerAngles.z - 90;
        ProjectileObject.transform.Rotate(new Vector3(0, 0, angle));

        if (isClass)
        {
            ClassAttack();
        }
    }

    public void ClassAttack()
    {
        //가까운 타겟 Transform 가져오기
        Transform target = transform.parent.GetComponent<WeaponCenter>().GetCloseTarget();

        if (projectile == null)
            return;
        if (target == null)
            return;
        //타겟 vector 계산 (y 1을 더해야 타겟의 가운데)
        Vector3 targetPos = target.position + new Vector3(0, 0.5f, 0);
        //플레이어 -> 타겟 벡터
        Vector3 difVec3 = targetPos - transform.position;

        //투사체 생성
        GameObject ProjectileObject = Instantiate(projectile, transform);
        //투사체 부모 오브젝트 제거
        ProjectileObject.transform.parent = null;
        ProjectileObject.SetActive(true);

        //투사체 크기 설정
        ProjectileObject.GetComponent<Projectile>().SetSize(1 + level/2.0f);
        //투사체 타겟 방향으로 각도 설정
        ProjectileObject.transform.Rotate(new Vector3(0, 0, Quaternion.FromToRotation(Vector3.up, difVec3).eulerAngles.z - 90));
        //투사체 타겟 방향으로 이동
        ProjectileObject.GetComponent<Rigidbody2D>().AddForce(difVec3.normalized * 50 * speed);
    }

    public void Upgrade()
    {
        if (!Player_Status.instance.HasClass(classIdx) && level >= 5)
        {
            isClass = true;
        }
    }
}

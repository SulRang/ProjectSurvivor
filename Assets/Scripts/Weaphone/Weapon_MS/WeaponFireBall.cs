using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFireBall : Weaphone
{
    [SerializeField]
    bool isUpgrade = false;
    [SerializeField]
    bool isClass = false;
    [SerializeField]
    GameObject classProjectile;
    [SerializeField]
    GameObject accessory;
    [SerializeField]
    int classIdx = 7;
    [SerializeField]
    int level = 1;
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
        SetCoolDown(10.0f);
    }

    public void levelUp()
    {
        level++;
        SetCoolDown(10.0f - (level));
    }


    public override void Attack()
    {
        if (level >= 5 && !isClass)
            Upgrade();
        //가까운 타겟 Transform 가져오기
        Transform target = transform.parent.GetComponent<WeaponCenter>().GetCloseTarget();
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

        if (isUpgrade)
            ProjectileObject.GetComponent<FireBallProjectile>().Upgrade();

        if (isClass)
        {
            ClassAttack();
        }
    }

    void ClassAttack()
    {
        if (projectile == null)
            return;
        GameObject ProjectileObject;
        for (int i = 0; i < projectileNum + level / 2; i++)
        {
            //랜덤한 타겟 Transform 가져오기
            Transform target = transform.parent.GetComponent<WeaponCenter>().GetRandomTarget();
            if (target == null)
                return;
            //타겟 vector 계산 (y 1을 더해야 타겟의 가운데)
            Vector3 targetPos = target.position + new Vector3(0, 0.5f, 0);
            ProjectileObject = Instantiate(classProjectile, target);
            //투사체 부모 오브젝트 제거
            ProjectileObject.transform.parent = null;
            ProjectileObject.SetActive(true);
            ProjectileObject.GetComponent<Projectile>().SetDuration(12.0f);
            ProjectileObject.transform.position += new Vector3(12.0f, 12.0f);
        }
    }
    public void Upgrade()
    {
        if (!Player_Status.instance.HasClass(classIdx) && !isUpgrade && level >= 5)
        {
            isClass = true;
        }
    }

    public void UpgradeWithAcc()
    {
        if (accessory.activeSelf && !isClass && level >= 5)
        {
            isUpgrade = true;
        }
    }
}

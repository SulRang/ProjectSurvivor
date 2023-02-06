using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTornado : Weaphone
{
    int count = 0;
    int level = 0;
    [SerializeField]
    bool isUpgrade = false;
    [SerializeField]
    bool isClass = false;
    [SerializeField]
    GameObject accessory;
    [SerializeField]
    int classIdx = 9;

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
        SetCoolDown(1.0f);
    }
    public void levelUp()
    {
        level++;
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

        //투사체 생성
        GameObject ProjectileObject = Instantiate(projectile, target);
        //투사체 부모 오브젝트 제거
        ProjectileObject.transform.parent = null;
        ProjectileObject.SetActive(true);
        //투사체 크기 설정
        ProjectileObject.GetComponent<Projectile>().SetSize(1 + level / 2);
        //투사체 지속 시간 설정
        ProjectileObject.GetComponent<Projectile>().SetDuration(1.0f);

        if (isClass)
            ClassAttack();
    }



    public void ClassAttack()
    {
        if (count > 4)
        {
            for (int i = 0; i < 8; i++)
            {
                //투사체 개수에 따른 각도 설정
                float degree = 360 / 8 * i;
                float radian = Mathf.Deg2Rad * degree;
                //투사체 생성
                GameObject ProjectileObject = Instantiate(projectile, transform);
                ProjectileObject.SetActive(true);
                ProjectileObject.transform.parent = null;
                //투사체 지속시간 설정
                ProjectileObject.GetComponent<Projectile>().SetDuration(2.0f);
                //투사체 각도 및 이동 설정
                //ProjectileObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 90 - degree));
                Vector3 dirVec3 = new Vector3(range * Mathf.Sin(radian), range * Mathf.Cos(radian));
                ProjectileObject.GetComponent<Rigidbody2D>().AddForce(dirVec3.normalized * 500);
            }
            count = 0;
        }
        else
            count++;
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

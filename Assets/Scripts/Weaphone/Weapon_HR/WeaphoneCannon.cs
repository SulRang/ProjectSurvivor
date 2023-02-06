using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaphoneCannon : Weaphone
{
    float radius = 10f;
    [SerializeField]
    GameObject upgradeProjectile;
    [SerializeField]
    GameObject accessory;
    [SerializeField]
    bool isUpgrade = false;
    float level = 1;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        //투사체 개수
        SetSpeed(200.0f);
        //공격 쿨다운
        SetCoolDown(5.0f);
    }

    public void LevelUp()
    {
        level++;
        SetCoolDown(5.0f / level);
        if (level >= 5)
        {
            UpgradeWithAcc();
        }
    }

    public override void Attack()
    {
        if (projectile == null)
            return;

        Collider2D[] Cols;
        Cols = Physics2D.OverlapCircleAll(transform.position, radius);

        for (int i = 0; i < Cols.Length; i++)
        {
            if (Cols[i].tag == "Monster")
            {
                GameObject CannonObject = Instantiate(projectile, Cols[i].transform);

                CannonObject.transform.parent = null;
                CannonObject.SetActive(true);

                CannonObject.GetComponent<Projectile>().SetDuration(0.5f);
                break;
            }
        }
        if (isUpgrade)
            UpgradeAttack();
    }

    void UpgradeAttack()
    {
        if (projectile == null)
            return;

        //투사체 생성
        GameObject ProjectileObject = Instantiate(upgradeProjectile, transform);
        //투사체 부모 오브젝트 제거
        ProjectileObject.transform.parent = null;
        ProjectileObject.SetActive(true);
        //투사체 지속 시간 설정
        ProjectileObject.GetComponent<Projectile>().SetDuration(10f);
    }

    public void UpgradeWithAcc()
    {
        if (level >= 5 && accessory.GetComponent<Accessory>().GetLevel() >= 5)
        {
            isUpgrade = true;
        }
    }
}

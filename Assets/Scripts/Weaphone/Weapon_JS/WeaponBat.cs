using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBat : Weaphone
{

    [SerializeField]
    Player_Move player;

    [SerializeField]
    WeaponCenter weaponCenter;

    [SerializeField]
    GameObject oldBook;

    [SerializeField]
    GameObject upgradeObj;
    protected override void Start()
    {
        base.Start();
        SetProjectileNum(1);
        SetSpeed(50.0f);
        SetCoolDown(2.5f);
        this.gameObject.transform.SetParent(player.transform);
    }

    public void LevelUp()
    {
        ++level;
        SetProjectileNum(level);
        if (level >= 5)
        {
            UpgradeWithACC();
        }
    }

    public override void Attack()
    {
        SetCoolDown(2.5f);

        for (int i = 0; i < projectileNum; i++)
        {
            Transform target = weaponCenter.GetRandomTarget();
            if (projectile == null)
                return;
            if (target == null)
                return;

            Vector3 targetPos = target.position + new Vector3(0, 1, 0);

            GameObject ProjectileObject = Instantiate(projectile, transform.position, Quaternion.identity);
            ProjectileObject.transform.parent = null;
            ProjectileObject.SetActive(true);

            ProjectileObject.GetComponent<Projectile>().SetDuration(2.0f);
            ProjectileObject.transform.Rotate(new Vector3(0, 0, Quaternion.FromToRotation(Vector3.up, targetPos - transform.position).eulerAngles.z));
            ProjectileObject.GetComponent<Rigidbody2D>().AddForce((targetPos - transform.position).normalized * 10 * speed);
        }
    }

    // 정령 업그레이드. 조건은 고서와 정령 모두 5레벨 이상. 공격속도가 매우 빨라짐
    public void UpgradeWithACC()
    {
        if (oldBook.GetComponent<ACC_OldBook>().GetLevel() >= 5 && level >= 5)
        {
            upgradeObj.SetActive(true);
            SetCoolDown(0.3f);
        }
    }
}

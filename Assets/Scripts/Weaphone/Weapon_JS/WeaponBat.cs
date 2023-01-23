using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBat : Weaphone
{
    [SerializeField]
    int level = 1;

    [SerializeField]
    Player_Move player;

    [SerializeField]
    WeaphoneCenter weaponCenter;

    protected override void Start()
    {
        base.Start();
        SetProjectileNum(level);
        SetSpeed(50.0f);
        SetCoolDown(2.0f);
        this.gameObject.transform.SetParent(player.transform);
    }

    void LevelUp()
    {
        ++level;
    }

    public override void Attack()
    {
        for (int i = 0; i < level; i++)
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
}

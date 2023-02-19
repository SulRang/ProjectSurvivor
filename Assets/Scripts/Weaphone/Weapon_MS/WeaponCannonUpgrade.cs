using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCannonUpgrade : Weaphone
{
    /// <summary>
    /// ������ Ÿ������ ����ü�� ��ȯ�ϴ� ����
    /// </summary>
    protected override void Start()
    {
        base.Start();
        //����ü ����
        SetProjectileNum(1);
        //����ü �ӵ�
        SetSpeed(100.0f);
        //���� ��ٿ�
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

        //����ü ����
        GameObject ProjectileObject = Instantiate(projectile, transform);
        //����ü �θ� ������Ʈ ����
        ProjectileObject.transform.parent = null;
        ProjectileObject.SetActive(true);
        //����ü ���� �ð� ����
        ProjectileObject.GetComponent<Projectile>().SetDuration(10f);
    }
}

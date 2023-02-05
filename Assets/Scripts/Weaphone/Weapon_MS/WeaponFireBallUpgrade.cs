using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFireBallUpgrade : Weaphone
{
    [SerializeField]
    int level = 1;
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
            //������ Ÿ�� Transform ��������
            Transform target = transform.parent.GetComponent<WeaponCenter>().GetRandomTarget();
            if (target == null)
                return;
            //Ÿ�� vector ��� (y 1�� ���ؾ� Ÿ���� ���)
            Vector3 targetPos = target.position + new Vector3(0, 0.5f, 0);
            ProjectileObject = Instantiate(projectile, target);
            //����ü �θ� ������Ʈ ����
            ProjectileObject.transform.parent = null;
            ProjectileObject.SetActive(true);
            ProjectileObject.GetComponent<Projectile>().SetDuration(12.0f);
            ProjectileObject.transform.position += new Vector3(12.0f, 12.0f);
        }
    }
}

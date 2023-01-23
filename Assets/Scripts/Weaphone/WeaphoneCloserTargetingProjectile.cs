using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaphoneCloserTargetingProjectile : Weaphone
{
    /// <summary>
    /// ����� Ÿ������ ����ü�� ��ȯ�ϴ� ����
    /// </summary>
    protected override void Start()
    {
        base.Start();
        //����ü ����
        SetProjectileNum(1);
        //����ü �ӵ�
        SetSpeed(0.0f);
        //���� ��ٿ�
        SetCoolDown(1.0f);
    }

    public override void Attack()
    {
        //����� Ÿ�� Transform ��������
        Transform target = transform.parent.GetComponent<WeaphoneCenter>().GetCloseTarget();
        if (projectile == null)
            return;
        if (target == null)
            return;
        //Ÿ�� vector ��� (y 1�� ���ؾ� Ÿ���� ���)
        Vector3 targetPos = target.position + new Vector3(0, 1, 0);

        //����ü ����
        GameObject ProjectileObject = Instantiate(projectile, transform);
        ProjectileObject.SetActive(true);

        //����ü ���� �ð� ����
        ProjectileObject.GetComponent<Projectile>().SetDuration(0.5f);
        //����ü Ÿ�� �������� ���� ����
        float angle = Quaternion.FromToRotation(Vector3.up, targetPos - transform.position).eulerAngles.z;
        ProjectileObject.transform.Rotate(new Vector3(0,0,angle));
    }

}

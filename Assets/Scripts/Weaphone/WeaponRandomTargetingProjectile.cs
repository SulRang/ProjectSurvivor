using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRandomTargetingProjectile : Weaphone
{
    /// <summary>
    /// ������ Ÿ������ ����ü�� ������ ����
    /// </summary>
    protected override void Start()
    {
        base.Start();
        //����ü ����
        SetProjectileNum(1);
        //����ü �ӵ�
        SetSpeed(100.0f);
        //���� ��ٿ�
        SetCoolDown(1.0f);
    }

    public override void Attack()
    {
        //������ Ÿ�� Transform ��������
        Transform target = transform.parent.GetComponent<WeaponCenter>().GetRandomTarget();
        if (projectile == null)
            return;
        if (target == null)
            return;
        //Ÿ�� vector ��� (y 1�� ���ؾ� Ÿ���� ���)
        Vector3 targetPos = target.position + new Vector3(0, 1, 0);

        //����ü ����
        GameObject ProjectileObject = Instantiate(projectile, transform);
        //����ü �θ� ������Ʈ ����
        ProjectileObject.transform.parent = null;
        ProjectileObject.SetActive(true);

        //����ü ���� �ð� ����
        ProjectileObject.GetComponent<Projectile>().SetDuration(2.0f);
        //����ü Ÿ�� �������� ���� ����
        ProjectileObject.transform.Rotate(new Vector3(0, 0, Quaternion.FromToRotation(Vector3.up, targetPos - transform.position).eulerAngles.z));
        //����ü Ÿ�� �������� �̵�
        ProjectileObject.GetComponent<Rigidbody2D>().AddForce((targetPos - transform.position).normalized * 10 * speed);
    }

}

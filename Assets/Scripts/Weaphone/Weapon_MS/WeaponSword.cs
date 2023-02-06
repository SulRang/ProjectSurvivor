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
    /// ����� Ÿ������ ����ü�� ������ ����
    /// </summary>
    protected override void Start()
    {
        base.Start();
        //����ü ����
        SetProjectileNum(1);
        //����ü �ӵ�
        SetSpeed(speed);
        //���� ��ٿ�
        SetCoolDown(8.0f / (level));
    }

    public void LevelUp()
    {
        level++;
        SetCoolDown(8.0f / (level));
    }


    public override void Attack()
    {
        //����� Ÿ�� Transform ��������
        Transform target = transform.parent.GetComponent<WeaponCenter>().GetCloseTarget();
        if (projectile == null)
            return;
        if (target == null)
            return;
        //Ÿ�� vector ��� (y 1�� ���ؾ� Ÿ���� ���)
        Vector3 targetPos = target.position + new Vector3(0, 0.5f, 0);

        //����ü ����
        GameObject ProjectileObject = Instantiate(projectile, transform);
        ProjectileObject.SetActive(true);
        //����ü ���� �ð� ����
        ProjectileObject.GetComponent<Projectile>().SetDuration(0.5f);
        ProjectileObject.GetComponent<Projectile>().SetSize(1 + level / 2);

        //����ü Ÿ�� �������� ���� ����
        float angle = Quaternion.FromToRotation(Vector3.up, targetPos - transform.position).eulerAngles.z - 90;
        ProjectileObject.transform.Rotate(new Vector3(0, 0, angle));

        if (isClass)
        {
            ClassAttack();
        }
    }

    public void ClassAttack()
    {
        //����� Ÿ�� Transform ��������
        Transform target = transform.parent.GetComponent<WeaponCenter>().GetCloseTarget();

        if (projectile == null)
            return;
        if (target == null)
            return;
        //Ÿ�� vector ��� (y 1�� ���ؾ� Ÿ���� ���)
        Vector3 targetPos = target.position + new Vector3(0, 0.5f, 0);
        //�÷��̾� -> Ÿ�� ����
        Vector3 difVec3 = targetPos - transform.position;

        //����ü ����
        GameObject ProjectileObject = Instantiate(projectile, transform);
        //����ü �θ� ������Ʈ ����
        ProjectileObject.transform.parent = null;
        ProjectileObject.SetActive(true);

        //����ü ũ�� ����
        ProjectileObject.GetComponent<Projectile>().SetSize(1 + level/2.0f);
        //����ü Ÿ�� �������� ���� ����
        ProjectileObject.transform.Rotate(new Vector3(0, 0, Quaternion.FromToRotation(Vector3.up, difVec3).eulerAngles.z - 90));
        //����ü Ÿ�� �������� �̵�
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

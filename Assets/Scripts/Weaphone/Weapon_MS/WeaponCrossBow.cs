using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCrossBow : Weaphone
{
    int level = 1;
    [SerializeField]
    bool isUpgrade = false;
    /// <summary>
    /// ����� Ÿ������ ����ü�� ������ ����
    /// </summary>
    protected override void Start()
    {
        base.Start();
        //����ü ����
        SetProjectileNum(1);
        //����ü �ӵ�
        SetSpeed(100.0f);
        //���� ��ٿ�
        SetCoolDown(8.0f / (level + 1));
    }

    public void LevelUp()
    {
        level++;
    }


    public override void Attack()
    {
        //����� Ÿ�� Transform ��������
        Transform target = transform.parent.GetComponent<WeaponCenter>().GetCloseTarget();

        if (projectile == null)
            return;
        if (target == null)
            return;
        //Ÿ�� vector ��� (y 0.5f�� ���ؾ� Ÿ���� ���)
        Vector3 targetPos = target.position + new Vector3(0, 0.5f, 0);
        //�÷��̾� -> Ÿ�� ����
        Vector3 difVec3 = targetPos - transform.position;

        //����ü ����
        GameObject ProjectileObject = Instantiate(projectile, transform);
        //����ü �θ� ������Ʈ ����
        ProjectileObject.transform.parent = null;
        ProjectileObject.SetActive(true);

        //����ü ���� �ð� ����
        ProjectileObject.GetComponent<Projectile>().SetDuration(2.0f);
        if (isUpgrade)
            ProjectileObject.GetComponent<CrossbowBoltProjectile>().Upgrade();
        //����ü Ÿ�� �������� ���� ����
        ProjectileObject.transform.Rotate(new Vector3(0, 0, Quaternion.FromToRotation(Vector3.up, difVec3).eulerAngles.z));
        //����ü Ÿ�� �������� �̵�
        ProjectileObject.GetComponent<Rigidbody2D>().AddForce(difVec3.normalized * 10 * speed);
    }
}

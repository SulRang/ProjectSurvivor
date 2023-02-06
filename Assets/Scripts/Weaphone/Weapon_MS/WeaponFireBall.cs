using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFireBall : Weaphone
{
    [SerializeField]
    bool isUpgrade = false;
    [SerializeField]
    bool isClass = false;
    [SerializeField]
    GameObject classProjectile;
    [SerializeField]
    GameObject accessory;
    [SerializeField]
    int classIdx = 7;
    [SerializeField]
    int level = 1;
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
        SetCoolDown(10.0f);
    }

    public void levelUp()
    {
        level++;
        SetCoolDown(10.0f - (level));
    }


    public override void Attack()
    {
        if (level >= 5 && !isClass)
            Upgrade();
        //����� Ÿ�� Transform ��������
        Transform target = transform.parent.GetComponent<WeaponCenter>().GetCloseTarget();
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

        if (isUpgrade)
            ProjectileObject.GetComponent<FireBallProjectile>().Upgrade();

        if (isClass)
        {
            ClassAttack();
        }
    }

    void ClassAttack()
    {
        if (projectile == null)
            return;
        GameObject ProjectileObject;
        for (int i = 0; i < projectileNum + level / 2; i++)
        {
            //������ Ÿ�� Transform ��������
            Transform target = transform.parent.GetComponent<WeaponCenter>().GetRandomTarget();
            if (target == null)
                return;
            //Ÿ�� vector ��� (y 1�� ���ؾ� Ÿ���� ���)
            Vector3 targetPos = target.position + new Vector3(0, 0.5f, 0);
            ProjectileObject = Instantiate(classProjectile, target);
            //����ü �θ� ������Ʈ ����
            ProjectileObject.transform.parent = null;
            ProjectileObject.SetActive(true);
            ProjectileObject.GetComponent<Projectile>().SetDuration(12.0f);
            ProjectileObject.transform.position += new Vector3(12.0f, 12.0f);
        }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTornado : Weaphone
{
    int count = 0;
    int level = 0;
    [SerializeField]
    bool isUpgrade = false;
    [SerializeField]
    bool isClass = false;
    [SerializeField]
    GameObject accessory;
    [SerializeField]
    int classIdx = 9;

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
        SetCoolDown(1.0f);
    }
    public void levelUp()
    {
        level++;
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
        Vector3 targetPos = target.position + new Vector3(0, 0.5f, 0);

        //����ü ����
        GameObject ProjectileObject = Instantiate(projectile, target);
        //����ü �θ� ������Ʈ ����
        ProjectileObject.transform.parent = null;
        ProjectileObject.SetActive(true);
        //����ü ũ�� ����
        ProjectileObject.GetComponent<Projectile>().SetSize(1 + level / 2);
        //����ü ���� �ð� ����
        ProjectileObject.GetComponent<Projectile>().SetDuration(1.0f);

        if (isClass)
            ClassAttack();
    }



    public void ClassAttack()
    {
        if (count > 4)
        {
            for (int i = 0; i < 8; i++)
            {
                //����ü ������ ���� ���� ����
                float degree = 360 / 8 * i;
                float radian = Mathf.Deg2Rad * degree;
                //����ü ����
                GameObject ProjectileObject = Instantiate(projectile, transform);
                ProjectileObject.SetActive(true);
                ProjectileObject.transform.parent = null;
                //����ü ���ӽð� ����
                ProjectileObject.GetComponent<Projectile>().SetDuration(2.0f);
                //����ü ���� �� �̵� ����
                //ProjectileObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 90 - degree));
                Vector3 dirVec3 = new Vector3(range * Mathf.Sin(radian), range * Mathf.Cos(radian));
                ProjectileObject.GetComponent<Rigidbody2D>().AddForce(dirVec3.normalized * 500);
            }
            count = 0;
        }
        else
            count++;
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

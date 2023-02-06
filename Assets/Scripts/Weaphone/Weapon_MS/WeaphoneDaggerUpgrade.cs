using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaphoneDaggerUpgrade : Weaphone
{
    public static Vector3 Direction; //��� ����
    static int Radius = 8;

    [SerializeField]
    bool isUpgrade = false;

    [SerializeField]
    bool isClass = false;

    [SerializeField]
    GameObject upgradProjectile;

    [SerializeField]
    GameObject accessory;

    public Collider2D[] Cols;
    int stackCount = 0;
    int level = 1;

    [SerializeField]
    int classIdx = 5;
    

    protected override void Start()
    {
        base.Start();
    }

    public void LevelUp()
    {
        level++;
    }


    public override void Attack()
    {
        if (projectile == null)
            return;
        BasicAttack();

        if (isUpgrade)
            UpgradeAttack();

        if (isClass)
            ClassAttack();
    }

    void BasicAttack()
    {
        Vector3 interV;

        Cols = Physics2D.OverlapCircleAll(transform.position, Radius);

        for (int i = 0; i < Cols.Length; i++)
        {
            if (Cols[i].tag == "Monster")
            {
                interV = Cols[i].transform.position - transform.position;
                float theta = Mathf.Acos(interV.normalized.x);
                float degree = interV.normalized.y > 0 ? Mathf.Rad2Deg * theta : Mathf.Rad2Deg * theta * (-1);

                GameObject LazerObject = Instantiate(projectile,
                    new Vector3(transform.position.x, transform.position.y, transform.position.z),
                    Quaternion.Euler(interV.normalized));

                LazerObject.transform.parent = null;
                LazerObject.SetActive(true);

                LazerObject.GetComponentInChildren<Projectile>().SetDuration(2.0f);
                LazerObject.GetComponent<DaggerTurning>().SetMax(level);
                LazerObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, degree));
                LazerObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(interV.normalized.x, interV.normalized.y) * 500);
                break;
            }
        }

    }

    void UpgradeAttack()
    {
        if (stackCount > 4)
        {
            for (int i = 0; i < 8; i++)
            {
                //����ü ������ ���� ���� ����
                float degree = 360 / 8 * i;
                float radian = Mathf.Deg2Rad * degree;
                //����ü ����
                GameObject LazerObject = Instantiate(projectile, transform);
                LazerObject.SetActive(true);
                LazerObject.transform.parent = null;
                //����ü ���ӽð� ����
                LazerObject.GetComponent<Projectile>().SetDuration(2.0f);
                LazerObject.GetComponent<DaggerTurning>().SetMax(level);
                //����ü ���� �� �̵� ����
                LazerObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 90 - degree));
                Vector3 dirVec3 = new Vector3(range * Mathf.Sin(radian), range * Mathf.Cos(radian));
                LazerObject.GetComponent<Rigidbody2D>().AddForce(dirVec3.normalized * 500);
            }
            stackCount = 0;
        }
        else
            stackCount++;

    }

    void ClassAttack()
    {
        if (projectile == null)
            return;
        for (int i = 0; i < projectileNum + level/2; i++)
        {
            //����� Ÿ�� Transform ��������
            Transform target = transform.parent.GetComponent<WeaponCenter>().GetRandomTarget();

            if (projectile == null)
                return;
            if (target == null)
                return;
            //Ÿ�� vector ��� (y 0.5f�� ���ؾ� Ÿ���� ���)
            Vector3 targetPos = target.position + new Vector3(0, 0.5f, 0);
            //�÷��̾� -> Ÿ�� ����
            Vector3 difVec3 = targetPos - transform.position;

            //����ü ����
            GameObject ProjectileObject = Instantiate(upgradProjectile, transform);
            //����ü �θ� ������Ʈ ����
            ProjectileObject.transform.parent = null;
            ProjectileObject.SetActive(true);

            //����ü ���� �ð� ����
            ProjectileObject.GetComponent<Projectile>().SetDuration(5.0f);
            if (isUpgrade)
                ProjectileObject.GetComponent<CrossbowBoltProjectile>().Upgrade();
            //����ü Ÿ�� �������� ���� ����
            ProjectileObject.transform.Rotate(new Vector3(0, 0, Quaternion.FromToRotation(Vector3.up, difVec3).eulerAngles.z));
            //����ü Ÿ�� �������� �̵�
            ProjectileObject.GetComponent<Rigidbody2D>().AddForce(difVec3.normalized * 100 * speed);
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
        if(accessory.GetComponent<ACC_MoneyPocket>().GetLevel() >= 5 && !isClass && level >= 5)
        {
            isUpgrade = true;
        }
    }
}

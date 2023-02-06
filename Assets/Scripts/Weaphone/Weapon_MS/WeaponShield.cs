using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShield : Weaphone
{
    [SerializeField]
    bool isUpgrade = false;
    [SerializeField]
    int level = 1;
    [SerializeField]
    GameObject accessory;
    /// <summary>
    /// ����ü ������ ���� ������ ������ 360���� �����ϴ� ����
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
    public void levelUp()
    {
        level++;
        SetProjectileNum(level);
    }

    private void Update()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }

    public override void Attack()
    {
        if (projectile == null)
            return;
        for(int i = 0; i < projectileNum; i++)
        {
            //����ü ������ ���� ���� ����
            float degree = 360.0f / (projectileNum) * i;
            float radian = Mathf.Deg2Rad * degree;
            //����ü ����
            GameObject shieldObject = Instantiate(projectile, transform);
            shieldObject.SetActive(true);
            //����ü ���ӽð� ����
            shieldObject.GetComponent<Projectile>().SetDuration(5.0f);
            //����ü ���� �� �̵� ����
            shieldObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -degree));
            shieldObject.transform.localPosition = new Vector3(range * Mathf.Sin(radian), range * Mathf.Cos(radian));
        }
        if (isUpgrade)
            UpgradeAttack();
    }

    //���׷��̵� �� �����ð����� ĳ�� �ֺ� ���� �о
    public void UpgradeAttack()
    {
        if (projectile == null)
            return;
        GameObject shieldObject = Instantiate(projectile, transform.parent);
        shieldObject.SetActive(true);
        //����ü ���ӽð� ����
        shieldObject.GetComponent<Projectile>().SetDuration(0.2f);
        shieldObject.GetComponent<Projectile>().SetSize(4.0f);
        shieldObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.2f);
    }

    public void UpgradeWithAcc()
    {
        if (accessory.activeSelf && level >= 5)
        {
            isUpgrade = true;
        }
    }
}

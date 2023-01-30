using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaphoneMaceUpgrade : Weaphone
{
    int level = 0;
    /// <summary>
    /// ���� �ð����� �ֺ��� �������� ��
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
        projectileNum += level;
    }

    private void Update()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }

    public override void Attack()
    {
        if (projectile == null)
            return;
        for(int i = 0; i < projectileNum + level; i++)
        {
            //����ü ������ ���� ���� ����
            float degree = 360.0f / (projectileNum + level) * i;
            float radian = Mathf.Deg2Rad * degree;
            //����ü ����
            GameObject shieldObject = Instantiate(projectile, transform);
            shieldObject.SetActive(true);
            //����ü ���ӽð� ����
            shieldObject.GetComponent<Projectile>().SetDuration(1.0f);
            //����ü ���� �� �̵� ����
            shieldObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -degree));
            shieldObject.transform.localPosition = new Vector3(range * Mathf.Sin(radian), range * Mathf.Cos(radian));
            shieldObject.transform.parent = null;
        }
    }
}

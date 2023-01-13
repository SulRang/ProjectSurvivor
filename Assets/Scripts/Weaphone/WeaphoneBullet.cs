using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaphoneBullet : Weaphone
{
    /// <summary>
    /// ����ü ������ ���� ������ ������ 360�� ���ư��� ����ü �����ϴ� ����
    /// </summary>
    protected override void Start()
    {
        base.Start();
        //����ü ����
        SetProjectileNum(5);
        //����ü �ӵ�
        SetSpeed(200.0f);
        //���� ��ٿ�
        SetCoolDown(5.0f);
    }

    public override void Attack()
    {
        if (projectile == null)
            return;
        for (int i = 0; i < projectileNum; i++)
        {
            //����ü ������ ���� ���� ����
            float degree = 360.0f/projectileNum * i;
            float radian = Mathf.Deg2Rad * degree;
            //����ü ����
            GameObject BulletObject = Instantiate(projectile, transform);
            //����ü �θ� ������Ʈ ����
            BulletObject.transform.parent = null;
            BulletObject.SetActive(true);
            //����ü ���ӽð� ����
            BulletObject.GetComponent<Projectile>().SetDuration(5.0f);
            //����ü ���� �� �̵� ����
            BulletObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -degree));
            BulletObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Sin(radian), Mathf.Cos(radian)) * speed);
        }
    }
}

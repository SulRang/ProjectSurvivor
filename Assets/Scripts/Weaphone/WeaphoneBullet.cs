using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaphoneBullet : Weaphone
{
    /// <summary>
    /// 투사체 개수에 따라 일정한 각도로 360도 날아가는 투사체 생성하는 무기
    /// </summary>
    protected override void Start()
    {
        base.Start();
        //투사체 개수
        SetProjectileNum(5);
        //투사체 속도
        SetSpeed(200.0f);
        //공격 쿨다운
        SetCoolDown(5.0f);
    }

    public override void Attack()
    {
        if (projectile == null)
            return;
        for (int i = 0; i < projectileNum; i++)
        {
            //투사체 개수에 따른 각도 설정
            float degree = 360.0f/projectileNum * i;
            float radian = Mathf.Deg2Rad * degree;
            //투사체 생성
            GameObject BulletObject = Instantiate(projectile, transform);
            //투사체 부모 오브젝트 제거
            BulletObject.transform.parent = null;
            BulletObject.SetActive(true);
            //투사체 지속시간 설정
            BulletObject.GetComponent<Projectile>().SetDuration(5.0f);
            //투사체 방향 및 이동 설정
            BulletObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -degree));
            BulletObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Sin(radian), Mathf.Cos(radian)) * speed);
        }
    }
}

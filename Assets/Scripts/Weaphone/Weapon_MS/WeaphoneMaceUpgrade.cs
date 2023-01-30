using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaphoneMaceUpgrade : Weaphone
{
    int level = 0;
    /// <summary>
    /// 일정 시간마다 주변에 데미지를 줌
    /// </summary>
    protected override void Start()
    {
        base.Start();
        //투사체 개수
        SetProjectileNum(1);
        //투사체 속도
        SetSpeed(100.0f);
        //공격 쿨다운
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
            //투사체 개수에 따른 각도 설정
            float degree = 360.0f / (projectileNum + level) * i;
            float radian = Mathf.Deg2Rad * degree;
            //투사체 생성
            GameObject shieldObject = Instantiate(projectile, transform);
            shieldObject.SetActive(true);
            //투사체 지속시간 설정
            shieldObject.GetComponent<Projectile>().SetDuration(1.0f);
            //투사체 각도 및 이동 설정
            shieldObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -degree));
            shieldObject.transform.localPosition = new Vector3(range * Mathf.Sin(radian), range * Mathf.Cos(radian));
            shieldObject.transform.parent = null;
        }
    }
}

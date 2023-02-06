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
    /// 투사체 개수에 따라 일정한 각도로 360도를 공전하는 무기
    /// </summary>
    protected override void Start()
    {
        base.Start();
        //투사체 개수
        SetProjectileNum(1);
        //투사체 속도
        SetSpeed(100.0f);
        //공격 쿨다운
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
            //투사체 개수에 따른 각도 설정
            float degree = 360.0f / (projectileNum) * i;
            float radian = Mathf.Deg2Rad * degree;
            //투사체 생성
            GameObject shieldObject = Instantiate(projectile, transform);
            shieldObject.SetActive(true);
            //투사체 지속시간 설정
            shieldObject.GetComponent<Projectile>().SetDuration(5.0f);
            //투사체 각도 및 이동 설정
            shieldObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -degree));
            shieldObject.transform.localPosition = new Vector3(range * Mathf.Sin(radian), range * Mathf.Cos(radian));
        }
        if (isUpgrade)
            UpgradeAttack();
    }

    //업그레이드 시 일정시간마다 캐릭 주변 적을 밀어냄
    public void UpgradeAttack()
    {
        if (projectile == null)
            return;
        GameObject shieldObject = Instantiate(projectile, transform.parent);
        shieldObject.SetActive(true);
        //투사체 지속시간 설정
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

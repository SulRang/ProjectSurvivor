using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBomb : Weaphone
{
    [SerializeField]
    float level = 1f;

    GameObject projectileObject;

    [SerializeField]
    GameObject scroll;

    [SerializeField]
    WeaponCenter weaponCenter;

    [SerializeField]
    int classIdx = 3;

    bool isUpgrade = false;

    bool isUpgradeWithACC = false;

    float upCooltime = 0f;

    protected override void Start()
    {
        base.Start();
        SetSpeed(0f);
        SetCoolDown((7f - level) * (1.0f - Player_Status.instance.COOLDOWN));
    }

    public void LevelUp()
    {
        ++level;
        // 전직 or 업그레이드 가능 여부 확인
        if (level >= 5)
        {
            if (scroll.GetComponent<ACC_Scroll>().GetLevel() >= 5)
            {
                UpgradeWithACC();
            }
            else
            {
                Upgrade();
            }
        }
    }

    public override void Attack()
    {
        SetCoolDown(7f - level);

        projectileObject = Instantiate(projectile, transform);

        // 업그레이드 되었을 경우 폭탄 크기 증가.
        if (isUpgradeWithACC)
        {
            projectileObject.GetComponent<BombProjectile>().SetSize(1.0f);
        }

        projectileObject.transform.parent = null;
        projectileObject.SetActive(true);
        projectileObject.GetComponent<BoxCollider2D>().enabled = false;

        projectileObject.GetComponent<BombProjectile>().explosionObj.SetActive(false);
    }

    // 폭탄 업그레이드. 조건은 주문서와 폭탄 모두 5레벨 이상. 폭탄 크기 크게 증가.
    public void UpgradeWithACC()
    {
        if (scroll.GetComponent<ACC_Scroll>().GetLevel() >= 5 && level >= 5 && !Player_Status.instance.HasClass(classIdx))
        {
            isUpgradeWithACC = true;

            // 사전에 전직이 되어있으면 해당 기능 취소.
            if (isUpgrade)
            {
                StopCoroutine(BeforeUpgradeAttackCoroutine());
                isUpgrade = false;
            }
        }
    }

    // 폭탄 전직. 조건은 폭탄 5레벨 이상. 일정 시간 간격으로 무작위 폭탄 투척
    public void Upgrade()
    {
        if (level >= 5 && !Player_Status.instance.HasClass(classIdx))
        {
            isUpgrade = true;
            StartCoroutine(BeforeUpgradeAttackCoroutine());
        }
    }

    // 무작위 폭탄 투척 시 사용 코루틴. 4초 간격으로 수행
    IEnumerator BeforeUpgradeAttackCoroutine()
    {
        while (isUpgrade)
        {
            upCooltime += Time.deltaTime;
            if (upCooltime >= 3f)
            {
                upCooltime -= 3f;
                UpgradeAttack();
                yield return new WaitForSeconds(1f);
            }
            yield return null;
        }
    }

    // 무작위 폭탄 생성 함수.
    void UpgradeAttack()
    {
        int targetNum = Random.Range(1, 6);

        for (int i = 0; i < level; i++)
        {
            Transform target = weaponCenter.GetRandomTarget();
            if (projectile == null)
                return;
            if (target == null)
                return;

            Vector3 targetPos = target.position + new Vector3(0, 1, 0);
            GameObject upProjectileObject = Instantiate(projectile, transform);
            upProjectileObject.transform.parent = null;
            upProjectileObject.SetActive(true);
            upProjectileObject.GetComponent<BoxCollider2D>().enabled = false;
            upProjectileObject.GetComponent<BombProjectile>().explosionObj.SetActive(false);

            upProjectileObject.GetComponent<Rigidbody2D>().AddForce((targetPos - transform.position).normalized * 75f);
        }

    }

}

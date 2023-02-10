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
        // ���� or ���׷��̵� ���� ���� Ȯ��
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

        // ���׷��̵� �Ǿ��� ��� ��ź ũ�� ����.
        if (isUpgradeWithACC)
        {
            projectileObject.GetComponent<BombProjectile>().SetSize(1.0f);
        }

        projectileObject.transform.parent = null;
        projectileObject.SetActive(true);
        projectileObject.GetComponent<BoxCollider2D>().enabled = false;

        projectileObject.GetComponent<BombProjectile>().explosionObj.SetActive(false);
    }

    // ��ź ���׷��̵�. ������ �ֹ����� ��ź ��� 5���� �̻�. ��ź ũ�� ũ�� ����.
    public void UpgradeWithACC()
    {
        if (scroll.GetComponent<ACC_Scroll>().GetLevel() >= 5 && level >= 5 && !Player_Status.instance.HasClass(classIdx))
        {
            isUpgradeWithACC = true;

            // ������ ������ �Ǿ������� �ش� ��� ���.
            if (isUpgrade)
            {
                StopCoroutine(BeforeUpgradeAttackCoroutine());
                isUpgrade = false;
            }
        }
    }

    // ��ź ����. ������ ��ź 5���� �̻�. ���� �ð� �������� ������ ��ź ��ô
    public void Upgrade()
    {
        if (level >= 5 && !Player_Status.instance.HasClass(classIdx))
        {
            isUpgrade = true;
            StartCoroutine(BeforeUpgradeAttackCoroutine());
        }
    }

    // ������ ��ź ��ô �� ��� �ڷ�ƾ. 4�� �������� ����
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

    // ������ ��ź ���� �Լ�.
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

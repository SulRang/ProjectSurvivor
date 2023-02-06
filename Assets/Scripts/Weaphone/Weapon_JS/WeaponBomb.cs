using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBomb : Weaphone
{
    [SerializeField]
    float level = 1f;

    [SerializeField]
    GameObject explosionPrefab;

    GameObject explosionObject;

    GameObject projectileObject;

    [SerializeField]
    GameObject scroll;

    [SerializeField]
    WeaponCenter weaponCenter;

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
        explosionObject = Instantiate(explosionPrefab, transform);
        explosionObject.transform.SetParent(projectileObject.transform);
        explosionObject.SetActive(false);

        float _setDuration = projectileObject.GetComponent<BombProjectile>()._setDuration;
    }

    void explosion()
    {
        explosionObject.SetActive(true);
        explosionObject.GetComponentInParent<BoxCollider2D>().enabled = true;
    }

    // ��ź ���׷��̵�. ������ �ֹ����� ��ź ��� 5���� �̻�. ��ź ũ�� ũ�� ����.
    public void UpgradeWithACC()
    {
        if (scroll.GetComponent<ACC_Scroll>().GetLevel() >= 5 && level >= 5)
        {
            isUpgradeWithACC = true;
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
        if (level >= 5)
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
            GameObject upExplosionObject = Instantiate(explosionPrefab, transform);
            upExplosionObject.transform.SetParent(upProjectileObject.transform);
            upExplosionObject.SetActive(false);

            float _setDuration = upProjectileObject.GetComponent<BombProjectile>()._setDuration;

            upProjectileObject.GetComponent<Rigidbody2D>().AddForce((targetPos - transform.position).normalized * 75f);
        }

    }

}

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
    bool isUpgrade = false;

    protected override void Start()
    {
        base.Start();
        SetSpeed(0f);
        SetCoolDown(7f - level - Player_Status.instance.Cooldown);
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
        if (isUpgrade)
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
        Invoke("explosion", _setDuration - 0.4f);
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
            isUpgrade = true;
        }
    }

}

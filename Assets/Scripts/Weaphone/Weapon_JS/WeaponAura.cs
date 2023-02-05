using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAura : MonoBehaviour
{
    //Monster���� (int)damage ���� �������� 1 ���Ϸ� ������ �� ����. ���� �ʿ�.
    [SerializeField]
    float damage = 1f;

    [SerializeField]
    int level = 1;

    [SerializeField]
    Player_Move player;

    [SerializeField]
    GameObject laurel;

    [SerializeField]
    GameObject upgradeObj;

    bool isUpgrade = false;

    float cooltime = 0f;


    void Start()
    {
        damage += Player_Status.instance.DMG;
        ScaleUpdate();
        this.gameObject.transform.SetParent(player.transform);
    }

    public void LevelUp()
    {
        ++level;
        ScaleUpdate();
    }

    // Scroll Ȱ��ȭ �� ���׷��̵�, ũ�� ���� ��ű� Ȱ��ȭ �� ���׷��̵� �� �����������
    public void ScaleUpdate()
    {
        transform.localScale = new Vector2((level * 1.5f) + 3 * Player_Status.instance.SIZE, (level * 1.5f) +  3 * Player_Status.instance.SIZE);
    }

    // ���� ���׷��̵�. ������ ������� ���� ��� 5���� �̻�. ������ �� ���� ����� ���׷��̵�
    public void UpgradeWithACC()
    {
        if (laurel.GetComponent<ACC_Laurel>().GetLevel() >= 5 && level >= 5)
        {
            // ������ ������ �Ǿ������� �ش� ��� ���.
            if (isUpgrade)
            {
                StopCoroutine(UpgradeAttackCoroutine());
                isUpgrade = false;
            } 
            upgradeObj.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    // ���� ����. ������ ���� 5���� �̻�. ������ �� ���� ���� ���� �ð� ���ݸ��� �߰� Ȱ��ȭ
    public void Upgrade()
    {
        if (level >= 5)
        {
            isUpgrade = true;
            StartCoroutine(UpgradeAttackCoroutine());
        }
    }

    // ���� ���� �� ��� �ڷ�ƾ. 3�� �������� 3�ʵ��� ���� Ȱ��ȭ
    IEnumerator UpgradeAttackCoroutine()
    {
        while (isUpgrade)
        {
            cooltime += Time.deltaTime;
            if (cooltime >= 3f)
            {
                cooltime -= 3f;
                upgradeObj.SetActive(true);
                yield return new WaitForSeconds(3f);
                upgradeObj.SetActive(false);
            }
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            collision.GetComponent<Monster>().GetDamage((int)damage);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            collision.GetComponent<Monster>().GetDamage((int)damage);
        }
    }
}

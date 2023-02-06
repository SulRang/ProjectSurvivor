using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
 * ��ű� - �Ź�
 * ��Ÿ�� (5��) ���� ���ӽð� (3 * (acc_Shoes_level / 2) ��) ���� 
 * �̵��ӵ� (inc_Speed) ��ŭ ����.
 * 
 */

public class ACC_Shoes : MonoBehaviour
{
    // ��ű� ����
    [SerializeField]
    static float acc_Shoes_level = 1f;

    // �����Ǵ� �̵��ӵ�. 0.5�� �����ϵ��� ���� ����
    [SerializeField]
    float inc_Speed = 1f;

    [SerializeField]
    float duration = 3f;

    // ��Ÿ�� 5��
    protected float cooldown = 5.0f;
    protected float cooltime = 0;

    IEnumerator BeforeSpeedincrease = null;

    void Start()
    {
        if (BeforeSpeedincrease == null)
        {
            BeforeSpeedincrease = HpDecreaseCoroutine();
            StartCoroutine(BeforeSpeedincrease);
        }
    }

    // ���� �� �Լ�. �������� �Բ� �ɷ�ġ ����
    public void LevelUp()
    {
        ++acc_Shoes_level;
        ++inc_Speed;
    }

    // ü�� ���� �ڷ�ƾ. ��Ÿ�� (5��) ���� ���ӽð� (3 * (level / 2. level 2����) ��) ���� �̵��ӵ� ����
    IEnumerator HpDecreaseCoroutine()
    {
        while (true)
        {
            cooltime += Time.deltaTime;
            if (cooltime >= cooldown)
            {
                Player_Status.instance.UpgradeStatus("Speed", inc_Speed);
                yield return new WaitForSeconds(duration * (acc_Shoes_level / 2));
                Player_Status.instance.UpgradeStatus("Speed", -inc_Speed);

                cooltime -= cooldown;
            }
            yield return new WaitForSeconds(0);
        }
    }

    public float GetLevel()
    {
        return acc_Shoes_level;
    }
}

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

    // �����Ǵ� �̵��ӵ�
    [SerializeField]
    float inc_Speed = 5f;

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

        // Debug.Log("�ʱ� �̵��ӵ� : " + Player_Status.instance.Speed);
    }

    // ���� �� �Լ�. �������� �Բ� �ɷ�ġ ����
    void LevelUp()
    {
        ++acc_Shoes_level;
        // Debug.Log("������ : " + acc_Shoes_level);
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
                // Debug.Log("�̼� ���� : " + Player_Status.instance.Speed);
                yield return new WaitForSeconds(duration * (acc_Shoes_level / 2));
                Player_Status.instance.UpgradeStatus("Speed", -inc_Speed);
                // Debug.Log("�̼� ���� : " + Player_Status.instance.Speed);

                cooltime -= cooldown;
                // LevelUp();
            }
            yield return new WaitForSeconds(0);
        }
    }
}

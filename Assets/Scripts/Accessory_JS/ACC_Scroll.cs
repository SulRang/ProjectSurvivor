using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
 * ��ű� - �ֹ���
 * ����ü ũ�Ⱑ (acc_Scroll_level * 0.1) ��ŭ ����.
 * Player_Status�� ���� ������ ���� ������� �ʴ� Duration(���ӽð�) ������ ��� ���.
 * �ش� ���� ���� �ʿ�.
 * ����ü ��ũ��Ʈ Projectile���� �ݿ� �ʿ�.
 * 
 */
public class ACC_Scroll : MonoBehaviour
{
    // ��ű� ����
    [SerializeField]
    static float acc_Scroll_level = 1f;

    // �����Ǵ� ����ü ũ��
    [SerializeField]
    float inc_Size = 0.1f;

    void Start()
    {
        Player_Status.instance.UpgradeStatus("Duration", inc_Size);
        // Debug.Log("�ʱ� ������ : " + Player_Status.instance.Duration);
    }

    // ���� �� �Լ�. �������� �Բ� �ɷ�ġ ����
    void LevelUp()
    {
        ++acc_Scroll_level;
        Player_Status.instance.UpgradeStatus("Duration", inc_Size);
        // Debug.Log("������ : " + acc_Scroll_level);
        // Debug.Log("�ݿ� ������ ���� : " + Player_Status.instance.Duration);
    }
}

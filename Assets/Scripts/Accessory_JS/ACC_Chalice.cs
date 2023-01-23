using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
 * ��ű� - ����
 * ü������� 0.5 �� ����.
 * 
 */
public class ACC_Chalice : MonoBehaviour
{
    // ��ű� ����
    [SerializeField]
    static float acc_Chalice_level = 1f;

    // �����Ǵ� ü�����
    [SerializeField]
    float inc_Regeneration = 0.5f;

    void Start()
    {
        Player_Status.instance.UpgradeStatus("Regeneration", inc_Regeneration);
        // Debug.Log("�ʱ� : " + Player_Status.instance.Regeneration);
    }

    // ���� �� �Լ�. �������� �Բ� �ɷ�ġ ����
    void LevelUp()
    {
        ++acc_Chalice_level;

        Player_Status.instance.UpgradeStatus("Regeneration", inc_Regeneration);
        // Debug.Log("������ : " + acc_Chalice_level);
        // Debug.Log("�ݿ� : " + Player_Status.instance.Regeneration);
    }
}

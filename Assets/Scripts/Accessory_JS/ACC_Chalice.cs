using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
 * ��ű� - ����
 * ü������� 1% �� ����.
 * 
 */
public class ACC_Chalice : MonoBehaviour
{
    // ��ű� ����
    [SerializeField]
    static float acc_Chalice_level = 1f;

    // �����Ǵ� ü�����. 1%�� �������� ���� ����
    [SerializeField]
    float inc_Regeneration = 1f;

    void Start()
    {
        Player_Status.instance.UpgradeStatus("Regeneration", inc_Regeneration);
    }

    // ���� �� �Լ�. �������� �Բ� �ɷ�ġ ����
    void LevelUp()
    {
        ++acc_Chalice_level;

        Player_Status.instance.UpgradeStatus("Regeneration", inc_Regeneration);
    }
}

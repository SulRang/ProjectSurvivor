using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * ��ű� - �����
 * ����ġ ȹ�淮�� (acc_Laurel_level * 0.2) ��ŭ ����.
 * 
 */

public class ACC_Laurel : MonoBehaviour
{
    // ��ű� ����
    [SerializeField]
    static float acc_Laurel_level = 1f;

    // �����Ǵ� ����ġ ȹ�淮. 0.2�� �������� ���� ����
    [SerializeField]
    float inc_Exp = 1f;

    void Start()
    {
        Player_Status.instance.UpgradeStatus("Exp_Gain_Rate", inc_Exp);
    }

    // ���� �� �Լ�. �������� �Բ� �ɷ�ġ ����
    public void LevelUp()
    {
        ++acc_Laurel_level;
        Player_Status.instance.UpgradeStatus("Exp_Gain_Rate", inc_Exp);
    }

    // ���� ���� ��ȯ
    public float GetLevel()
    {
        return acc_Laurel_level;
    }
}

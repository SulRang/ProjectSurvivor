using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��ű� - ����
/// ���� ������ (acc_Book_level * 0.1)��ŭ ����.
/// 
/// ���� ������ ������ ���� �ʾƼ� ACC_Scroll�� ���������� Duration ������ ��� ����ϰڽ��ϴ�.
/// </summary>

public class ACC_Ring : MonoBehaviour
{
    [SerializeField]
    static float acc_Ring_level = 1f;

    [SerializeField]
    float inc_Duration = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        Player_Status.instance.UpgradeStatus("Duration", inc_Duration);
    }

    // Update is called once per frame
    public void LevelUp()
    {
        ++acc_Ring_level;
        Player_Status.instance.UpgradeStatus("Duration", inc_Duration);
    }
    public float GetLevel()
    {
        return acc_Ring_level;
    }
    
}

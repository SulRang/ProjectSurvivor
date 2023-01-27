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

    [SerializeField]
    WeaponAura weaponAura;

    void Start()
    {
        Player_Status.instance.UpgradeStatus("Duration", inc_Size);
        weaponAura.ScaleUpdate();
    }

    // ���� �� �Լ�. �������� �Բ� �ɷ�ġ ����
    public void LevelUp()
    {
        ++acc_Scroll_level;
        Player_Status.instance.UpgradeStatus("Duration", inc_Size);
        weaponAura.ScaleUpdate();
    }

    public float GetLevel()
    {
        return acc_Scroll_level;
    }
}

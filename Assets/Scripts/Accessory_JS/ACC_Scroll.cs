using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
 * 장신구 - 주문서
 * 투사체 크기가 (acc_Scroll_level * 0.1) 만큼 증가.
 * Player_Status에 관련 변수가 없어 사용하지 않는 Duration(지속시간) 변수를 대신 사용.
 * 해당 변수 수정 필요.
 * 투사체 스크립트 Projectile에도 반영 필요.
 * 
 */
public class ACC_Scroll : MonoBehaviour
{
    // 장신구 레벨
    [SerializeField]
    static float acc_Scroll_level = 1f;

    // 증가되는 투사체 크기
    [SerializeField]
    float inc_Size = 0.1f;

    [SerializeField]
    WeaponAura weaponAura;

    void Start()
    {
        Player_Status.instance.UpgradeStatus("Duration", inc_Size);
        weaponAura.ScaleUpdate();
    }

    // 레벨 업 함수. 레벨업과 함께 능력치 조정
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

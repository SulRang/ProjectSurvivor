using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 장신구 - 월계관
 * 경험치 획득량이 (acc_Laurel_level * 0.2) 만큼 증가.
 * 
 */

public class ACC_Laurel : MonoBehaviour
{
    // 장신구 레벨
    [SerializeField]
    static float acc_Laurel_level = 1f;

    // 증가되는 경험치 획득량. 0.2씩 오르도록 변수 설정
    [SerializeField]
    float inc_Exp = 1f;

    void Start()
    {
        Player_Status.instance.UpgradeStatus("Exp_Gain_Rate", inc_Exp);
    }

    // 레벨 업 함수. 레벨업과 함께 능력치 조정
    public void LevelUp()
    {
        ++acc_Laurel_level;
        Player_Status.instance.UpgradeStatus("Exp_Gain_Rate", inc_Exp);
    }

    // 현재 레벨 반환
    public float GetLevel()
    {
        return acc_Laurel_level;
    }
}

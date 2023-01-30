using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
 * 장신구 - 성배
 * 체력재생이 0.5 씩 증가.
 * 
 */
public class ACC_Chalice : MonoBehaviour
{
    // 장신구 레벨
    [SerializeField]
    static float acc_Chalice_level = 1f;

    // 증가되는 체력재생
    [SerializeField]
    float inc_Regeneration = 0.5f;

    void Start()
    {
        Player_Status.instance.UpgradeStatus("Regeneration", inc_Regeneration);
    }

    // 레벨 업 함수. 레벨업과 함께 능력치 조정
    void LevelUp()
    {
        ++acc_Chalice_level;

        Player_Status.instance.UpgradeStatus("Regeneration", inc_Regeneration);
    }
}

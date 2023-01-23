using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 장신구 - 성배
/// 체력 재생 수치가 (acc_Glory_level * 0.2)만큼 증가.
/// </summary>

public class ACC_Glory : MonoBehaviour
{
    [SerializeField]
    static float acc_Glory_level = 1f;

    [SerializeField]
    float inc_Regeneration = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        Player_Status.instance.UpgradeStatus("Regeneration", inc_Regeneration);
    }

    // Update is called once per frame
    void LevelUp()
    {
        ++acc_Glory_level;
        Player_Status.instance.UpgradeStatus("Regeneration", inc_Regeneration);
    }
}

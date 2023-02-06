using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 장신구 - 반지
/// 공격 범위가 (acc_Book_level * 0.1)만큼 증가.
/// 
/// 공격 범위를 설정해 놓지 않아서 ACC_Scroll과 마찬가지로 Duration 변수를 대신 사용하겠습니다.
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

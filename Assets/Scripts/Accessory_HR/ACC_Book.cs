using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 장신구 - 책
/// 쿨다운 수치가 (acc_Book_level * 0.2)만큼 증가.
/// </summary>

public class ACC_Book : MonoBehaviour
{
    [SerializeField]
    static float acc_Book_level = 1f;

    [SerializeField]
    float inc_Cooldown = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        Player_Status.instance.UpgradeStatus("Cooldown", inc_Cooldown);
    }

    // Update is called once per frame
    public void LevelUp()
    {
        ++acc_Book_level;
        Player_Status.instance.UpgradeStatus("Cooldown", inc_Cooldown);
    }
}

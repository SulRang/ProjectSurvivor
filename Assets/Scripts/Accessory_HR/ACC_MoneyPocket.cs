using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ¿ÂΩ≈±∏ - µ∑¡÷∏”¥œ
/// ∞ÒµÂ »πµÊ∑Æ¿Ã (acc_Glory_level * 0.2)∏∏≈≠ ¡ı∞°.
/// </summary>

public class ACC_MoneyPocket : MonoBehaviour
{
    [SerializeField]
    static float acc_Gold_level = 1f;

    [SerializeField]
    float inc_Gold_Gain_Rate = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        Player_Status.instance.UpgradeStatus("Gold_Gain_Rate", inc_Gold_Gain_Rate);
    }

    // Update is called once per frame
    public void LevelUp()
    {
        ++acc_Gold_level;
        Player_Status.instance.UpgradeStatus("Gold_Gain_Rate", inc_Gold_Gain_Rate);
    }
    public float GetLevel()
    {
        return acc_Gold_level;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
 * 장신구 - 신발
 * 쿨타임 (5초) 마다 지속시간 (3 * (acc_Shoes_level / 2) 초) 동안 
 * 이동속도 (inc_Speed) 만큼 증가.
 * 
 */

public class ACC_Shoes : MonoBehaviour
{
    // 장신구 레벨
    [SerializeField]
    static float acc_Shoes_level = 1f;

    // 증가되는 이동속도. 0.5씩 증가하도록 변수 지정
    [SerializeField]
    float inc_Speed = 1f;

    [SerializeField]
    float duration = 3f;

    // 쿨타임 5초
    protected float cooldown = 5.0f;
    protected float cooltime = 0;

    IEnumerator BeforeSpeedincrease = null;

    void Start()
    {
        if (BeforeSpeedincrease == null)
        {
            BeforeSpeedincrease = HpDecreaseCoroutine();
            StartCoroutine(BeforeSpeedincrease);
        }
    }

    // 레벨 업 함수. 레벨업과 함께 능력치 조정
    public void LevelUp()
    {
        ++acc_Shoes_level;
        ++inc_Speed;
    }

    // 체력 감소 코루틴. 쿨타임 (5초) 마다 지속시간 (3 * (level / 2. level 2부터) 초) 동안 이동속도 증가
    IEnumerator HpDecreaseCoroutine()
    {
        while (true)
        {
            cooltime += Time.deltaTime;
            if (cooltime >= cooldown)
            {
                Player_Status.instance.UpgradeStatus("Speed", inc_Speed);
                yield return new WaitForSeconds(duration * (acc_Shoes_level / 2));
                Player_Status.instance.UpgradeStatus("Speed", -inc_Speed);

                cooltime -= cooldown;
            }
            yield return new WaitForSeconds(0);
        }
    }

    public float GetLevel()
    {
        return acc_Shoes_level;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 장신구 - 고서
 * 데미지가 (inc_Dmg * acc_OldBook_level) 만큼 증가하는 대신
 * 쿨타임 (5초) 마다 현재 체력의 (0.5% * acc_OldBook_level) 만큼 감소
 * 
 */
public class ACC_OldBook : MonoBehaviour
{
    // 장신구 레벨
    [SerializeField]
    static float acc_OldBook_level = 1f;

    // 증가되는 공격력
    [SerializeField]
    float inc_Dmg = 5f;

    // 감소되는 체력
    float dec_Hp = 0f;

    // 쿨타임 5초
    protected float cooldown = 5.0f;
    protected float cooltime = 0;

    IEnumerator BeforeHpDecrease = null;
    void Start()
    {
        Player_Status.instance.UpgradeStatus("Dmg", inc_Dmg);
        //Player_Status.instance.UpgradeStatus("Hp", 500);

        dec_Hp = -Player_Status.instance.Hp * 0.005f * acc_OldBook_level;
        Player_Status.instance.UpgradeStatus("Hp", dec_Hp);

        if (BeforeHpDecrease == null)
        {
            BeforeHpDecrease = HpDecreaseCoroutine();
            StartCoroutine(BeforeHpDecrease);
        }

    }

    // 레벨 업 함수. 레벨업과 함께 능력치 조정
    void LevelUp()
    {
        ++acc_OldBook_level;
        Player_Status.instance.UpgradeStatus("Dmg", inc_Dmg);
    }

    // 체력 감소 코루틴. 5초마다 체력의 0.5% * level 만큼 감소
    IEnumerator HpDecreaseCoroutine()
    {
        while (true)
        {
            cooltime += Time.deltaTime;
            if (cooltime >= cooldown)
            {
                cooltime -= cooldown;
                dec_Hp = -Player_Status.instance.Hp * 0.005f * acc_OldBook_level;
                Player_Status.instance.UpgradeStatus("Hp", dec_Hp);
            }
            yield return new WaitForSeconds(0);
        }
    }

    public float GetLevel()
    {
        return acc_OldBook_level;
    }
}

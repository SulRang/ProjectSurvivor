using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * ��ű� - ��
 * �������� (inc_Dmg * acc_OldBook_level) ��ŭ �����ϴ� ���
 * ��Ÿ�� (5��) ���� ���� ü���� (1% * acc_OldBook_level) ��ŭ ����
 * 
 */
public class ACC_OldBook : MonoBehaviour
{
    // ��ű� ����
    [SerializeField]
    static float acc_OldBook_level = 1f;

    // �����Ǵ� ���ݷ�. UpgradeStatus���� ��ġ �ݿ��ǹǷ� 1�� ����.
    [SerializeField]
    float inc_Dmg = 1f;

    // ���ҵǴ� ü��
    float dec_Hp = 0f;

    // ��Ÿ�� 5��
    protected float cooldown = 5.0f;
    protected float cooltime = 0;

    IEnumerator BeforeHpDecrease = null;
    void Start()
    {
        Player_Status.instance.UpgradeStatus("Dmg", inc_Dmg);

        dec_Hp = -Player_Status.instance.Current_Hp * 0.01f * acc_OldBook_level;
        Player_Status.instance.UpgradeStatus("Current_Hp", dec_Hp); // Hp ����.
        Debug.Log(Player_Status.instance.Current_Hp);


        if (BeforeHpDecrease == null)
        {
            BeforeHpDecrease = HpDecreaseCoroutine();
            StartCoroutine(BeforeHpDecrease);
        }

    }

    // ���� �� �Լ�. �������� �Բ� �ɷ�ġ ����
    public void LevelUp()
    {
        ++acc_OldBook_level;
        Player_Status.instance.UpgradeStatus("Dmg", inc_Dmg);
    }

    // ü�� ���� �ڷ�ƾ. 5�ʸ��� ü���� 0.5% * level ��ŭ ����
    IEnumerator HpDecreaseCoroutine()
    {
        while (true)
        {
            cooltime += Time.deltaTime;
            if (cooltime >= cooldown)
            {
                cooltime -= cooldown;
                dec_Hp = -Player_Status.instance.Hp * 0.01f * acc_OldBook_level;
                Player_Status.instance.UpgradeStatus("Hp", dec_Hp);
                Debug.Log(Player_Status.instance.Current_Hp);
            }
            yield return new WaitForSeconds(0);
        }
    }

    public float GetLevel()
    {
        return acc_OldBook_level;
    }
}

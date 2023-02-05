using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class Player_Status : MonoBehaviour
{
    //임시 싱글톤
    public static Player_Status instance;
    public static Player_Status Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType(typeof(Player_Status)) as Player_Status;
            }

            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    //테스트용 Start
    private void Start()
    {
        StatusUpdate();
        GameObject canvasObj;
        GameObject upgradeUI;
        if (canvasObj = GameObject.Find("Canvas"))
        {
            upgradeUI = canvasObj.transform.GetChild(2).gameObject;
            upgradeUI.GetComponent<UpgradeShopManager>().UpdateUpgrade();
        }
        UpgradeStatus("Speed", 8);
    }

    float pTime = 0;

    private void Update()
    {
        //Debug.Log(Time.time + ", " + pTime);
        //3초마다 한 번씩 체력회복
        if (Time.time - pTime > 3 && HP != Current_Hp)
        {
            Debug.Log(Current_Hp);
            Current_Hp *= (100 + REGENERATION) / 100;
            pTime = Time.time;
        }
    }

    float HitTime = 0;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Monster")
        {
            Debug.Log(Time.time + ", " + HitTime);
            //0.2초마다 한 번씩 데미지
            if (Time.time - pTime > 0.5)
            {
                Current_Hp -= 5;
                HitTime = Time.time;
                //Debug.Log(Current_Hp);
            }
        }
    }

    //표시용 스텟
    public float HP;
    public float DEF;
    public float DMG;
    public float SPEED;
    public float REGENERATION;
    public float COOLDOWN;
    public float SIZE;
    public float RANGE;
    public float PROJECTILE_COUNT;
    public float MAGNET;
    public float CRITICAL;
    public float CRITICAL_DMG;
    public float EXP_GAIN_RATE;
    public float GOLD_GAIN_RATE;
    public float FULL_EXP;

    //수정용 스텟
    public float _Current_Hp = 1000;               //현재 체력
    float _Current_Exp = 0;                 //현재 Exp
    float[] _Hp = { 1000, 0 };             //최대 체력        ( 500씩 상승 )
    float[] _Def = { 50, 0 };              //방어력           ( 공격력(피해량)의 [100 / (100 + a)%])
    float[] _Dmg = { 10, 0 };               //공격력           ( 5씩 상승 )
    float[] _Speed = { 3, 0 };             //추가 이동속도    ( 0.5씩 상승, 기본속도 3 )
    float[] _Regeneration = { 1, 0 };      //재생             ( 일정 주기마다 1 ~ 5% 회복 )
    float[] _Cooldown = { 0.05f, 0 };          //공격주기      (1당 5%)
    float[] _Size = { 1, 0 };             	    //발사체 크기 (1당 10%)
    float[] _range = { 1, 0 };               //사거리
    float[] _Projectile_Count = { 0, 0 };  //발사체 수량
    float[] _Magnet = { 1, 0 };              //아이템 획득 범위 ( 1씩 상승 )
    float[] _Critical = { 0.1f, 0 };            //치명률           ( 5%씩 상승 )
    float[] _Critical_Dmg = { 1.5f, 0 };   //치명타 데미지    ( 0.2씩 상승 )
    float[] _Exp_Gain_Rate = { 1, 0 };     //경험치 획득량    ( 0.2씩 상승 )
    float[] _Gold_Gain_Rate = { 1, 0 };    //골드 획득량      ( 0.2씩 상승 )
    float[] _Full_Exp = { 100, 0 };        //최대 경험치

    //Getter Setter
    public float Hp { get => _Hp[1]; set => _Hp[1] = value; }
    public float Def { get => _Def[1]; set => _Def[1] = value; }
    public float Dmg { get => _Dmg[1]; set => _Dmg[1] = value; }
    public float Speed { get => _Speed[1]; set => _Speed[1] = value; }
    public float Regeneration { get => _Regeneration[1]; set => _Regeneration[1] = value; }
    public float Cooldown { get => _Cooldown[1]; set => _Cooldown[1] = value; }
    public float Size { get => _Size[1]; set => _Size[1] = value; }
    public float Range { get => _range[1]; set => _range[1] = value; }
    public float Projectile_Count { get => _Projectile_Count[1]; set => _Projectile_Count[1] = value; }
    public float Magnet { get => _Magnet[1]; set => _Magnet[1] = value; }
    public float Critical { get => _Critical[1]; set => _Critical[1] = value; }
    public float Critical_Dmg { get => _Critical_Dmg[1]; set => _Critical_Dmg[1] = value; }
    public float Exp_Gain_Rate { get => _Exp_Gain_Rate[1]; set => _Exp_Gain_Rate[1] = value; }
    public float Gold_Gain_Rate { get => _Gold_Gain_Rate[1]; set => _Gold_Gain_Rate[1] = value; }
    public float Full_Exp { get => _Full_Exp[1]; set => _Full_Exp[1] = value; }
    // 레벨 ?
    public float Current_Hp { get => _Current_Hp; set => _Current_Hp = value; }
    public float Current_Exp { get => _Current_Exp; set => _Current_Exp = value; }

    //바뀐 Status 업데이트
    public void StatusUpdate()
    {
        HP = _Hp[0] + (_Hp[1] * 500);
        DEF = _Def[0] + (_Def[1] * 50);
        DMG = _Dmg[0] + (_Dmg[1] * 5);
        SPEED = _Speed[0] + (_Speed[1] * 0.5f);
        REGENERATION = _Regeneration[0] + (_Regeneration[1] * 0.05f);
        COOLDOWN = _Cooldown[0] + (_Cooldown[1] * 0.05f);
        SIZE = _Size[0] + (_Size[1] * 0.1f);
        RANGE = _range[0] + (_range[1] * 0.01f);
        PROJECTILE_COUNT = _Projectile_Count[0] + _Projectile_Count[1];
        MAGNET = _Magnet[0] + (_Magnet[1] * 0.5f);
        CRITICAL = _Critical[0] + (_Critical[1] * 0.05f);
        CRITICAL_DMG = _Critical_Dmg[0] + (_Critical_Dmg[1] * 0.2f);
        EXP_GAIN_RATE = _Exp_Gain_Rate[0] + (_Exp_Gain_Rate[1] * 0.2f);
        GOLD_GAIN_RATE = _Gold_Gain_Rate[0] + (_Gold_Gain_Rate[1] * 0.2f);
        FULL_EXP = _Full_Exp[0] + (_Full_Exp[1] * 100);
    }

    public void ExpCheck()
    {
        if (FULL_EXP < Current_Exp)
        {
            _Full_Exp[1]++;
            Current_Exp = Current_Exp - FULL_EXP;
            Debug.Log("Level UP!");
            StatusUpdate();
        }
    }

    /// UpgradeStatus("스탯 이름", 값)
    /// ex) UpgradeStatus("Hp", 1);
    /// 스탯 이름은 Getter Setter 참고
    public void UpgradeStatus(string _name, float _value)
    {
        foreach(PropertyInfo pInfo in typeof(Player_Status).GetProperties())
        {
            if (pInfo.Name == _name)
            {
                float pValue = (float)pInfo.GetValue(this);
                pInfo.SetValue(this, pValue + _value);
                break;
            }
        }
        StatusUpdate();
    }
}
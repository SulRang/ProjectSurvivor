using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class Player_Status : MonoBehaviour
{
    //�ӽ� �̱���
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

    //�׽�Ʈ�� Start
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

    //ǥ�ÿ� ����
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

    //������ ����
    float _Current_Hp = 1000;               //���� ü��
    float _Current_Exp = 0;                 //���� Exp
    float[] _Hp = { 1000, 0 };             //�ִ� ü��        ( 500�� ��� )
    float[] _Def = { 50, 0 };              //����           ( ���ݷ�(���ط�)�� [100 / (100 + a)%])
    float[] _Dmg = { 10, 0 };               //���ݷ�           ( 5�� ��� )
    float[] _Speed = { 3, 0 };             //�߰� �̵��ӵ�    ( 0.5�� ���, �⺻�ӵ� 3 )
    float[] _Regeneration = { 0, 0 };      //���             ( ���� �ֱ⸶�� 1 ~ 5% ȸ�� )
    float[] _Cooldown = { 0.05f, 0 };          //�����ֱ�      (1�� 5%)
    float[] _Size = { 1, 0 };             	    //�߻�ü ũ�� (1�� 10%)
    float[] _range = { 1, 0 };               //��Ÿ�
    float[] _Projectile_Count = { 0, 0 };  //�߻�ü ����
    float[] _Magnet = { 1, 0 };              //������ ȹ�� ���� ( 1�� ��� )
    float[] _Critical = { 0.1f, 0 };            //ġ���           ( 5%�� ��� )
    float[] _Critical_Dmg = { 1.5f, 0 };   //ġ��Ÿ ������    ( 0.2�� ��� )
    float[] _Exp_Gain_Rate = { 1, 0 };     //����ġ ȹ�淮    ( 0.2�� ��� )
    float[] _Gold_Gain_Rate = { 1, 0 };    //��� ȹ�淮      ( 0.2�� ��� )
    float[] _Full_Exp = { 100, 0 };        //�ִ� ����ġ

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
    public float Current_Hp { get => _Current_Hp; set => _Current_Hp = value; }
    public float Current_Exp { get => _Current_Exp; set => _Current_Exp = value; }

    //�ٲ� Status ������Ʈ
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

    /// UpgradeStatus("���� �̸�", ��)
    /// ex) UpgradeStatus("Hp", 1);
    /// ���� �̸��� Getter Setter ����
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
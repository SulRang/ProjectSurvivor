using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Status : MonoBehaviour
{
    Player_Move player_move;

    public float Hp;
    public float Def;
    public float Dmg;
    public float Speed;
    public float Regeneration;
    public float Cooldown;
    public float Duration;
    public float Range;
    public float Projectile_Count;
    public float Magnet;
    public float Critical;
    public float Critical_Dmg;
    public float Exp_Gain_Rate;
    public float Gold_Gain_Rate;
    public float Full_Exp;

    float[] _Hp = { 1000, 0 };             //�ִ� ü��        ( 500�� ��� )
    float[] _Def = { 50, 0 };              //����           ( ���ݷ�(���ط�)�� [100 / (100 + a)%])
    int[] _Dmg = { 100, 0 };               //���ݷ�           ( 50�� ��� )
    float[] _Speed = { 3, 0 };             //�߰� �̵��ӵ�    ( 0.5�� ���, �⺻�ӵ� 3 )
    float[] _Regeneration = { 0, 0 };      //���             ( ���� �ֱ⸶�� 1 ~ 5% ȸ�� )
    float[] _Cooldown = { 1, 0 };          //�����ֱ�         
    int[] _Duration = { 1, 0 };            //���ݹ���
    int[] _range = { 1, 0 };               //��Ÿ�
    float[] _Projectile_Count = { 1, 0 };  //�߻�ü ����
    int[] _Magnet = { 1, 0 };              //������ ȹ�� ���� ( 1�� ��� )
    int[] _Critical = { 0, 0 };            //ġ���           ( 20%�� ��� )
    float[] _Critical_Dmg = { 1.5f, 0 };   //ġ��Ÿ ������    ( 0.2�� ��� )
    float[] _Exp_Gain_Rate = { 1, 0 };     //����ġ ȹ�淮    ( 0.2�� ��� )
    float[] _Gold_Gain_Rate = { 1, 0 };    //��� ȹ�淮      ( 0.2�� ��� )
    float[] _Full_Exp = { 100, 0 };        //�ִ� ����ġ

    public float Current_Hp = 1000;
    public float Current_Exp = 0;

    void Start()
    {
        player_move = gameObject.GetComponent<Player_Move>();    
    }

    void Update()
    {
        Hp = _Hp[0] + (_Hp[1] * 500);
        Def = _Def[0] + (_Def[1] * 50);
        Dmg = _Dmg[0] + (_Dmg[1] * 50);
        Speed = _Speed[0] + (_Speed[1] * 0.5f);
        Magnet = _Magnet[0] + (_Magnet[1] * 0.5f);
        Critical = _Critical[0] + (_Critical[1] * 0.2f);
        Critical_Dmg = _Critical_Dmg[0] + (_Critical_Dmg[1] * 0.2f);
        Exp_Gain_Rate = _Exp_Gain_Rate[0] + (_Exp_Gain_Rate[1] * 0.2f);
        Full_Exp = _Full_Exp[0] + (_Full_Exp[1] * 100);
    }
}
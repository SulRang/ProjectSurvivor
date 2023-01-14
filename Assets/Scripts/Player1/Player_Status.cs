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

    float[] _Hp = { 1000, 0 };             //최대 체력        ( 500씩 상승 )
    float[] _Def = { 50, 0 };              //방어력           ( 공격력(피해량)의 [100 / (100 + a)%])
    int[] _Dmg = { 100, 0 };               //공격력           ( 50씩 상승 )
    float[] _Speed = { 3, 0 };             //추가 이동속도    ( 0.5씩 상승, 기본속도 3 )
    float[] _Regeneration = { 0, 0 };      //재생             ( 일정 주기마다 1 ~ 5% 회복 )
    float[] _Cooldown = { 1, 0 };          //공격주기         
    int[] _Duration = { 1, 0 };            //공격범위
    int[] _range = { 1, 0 };               //사거리
    float[] _Projectile_Count = { 1, 0 };  //발사체 수량
    int[] _Magnet = { 1, 0 };              //아이템 획득 범위 ( 1씩 상승 )
    int[] _Critical = { 0, 0 };            //치명률           ( 20%씩 상승 )
    float[] _Critical_Dmg = { 1.5f, 0 };   //치명타 데미지    ( 0.2씩 상승 )
    float[] _Exp_Gain_Rate = { 1, 0 };     //경험치 획득량    ( 0.2씩 상승 )
    float[] _Gold_Gain_Rate = { 1, 0 };    //골드 획득량      ( 0.2씩 상승 )
    float[] _Full_Exp = { 100, 0 };        //최대 경험치

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
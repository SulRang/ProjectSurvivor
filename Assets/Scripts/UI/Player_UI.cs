using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_UI : MonoBehaviour
{
    GameObject player;
    Player_Status player_status;

    public Slider Expbar;
    public Slider Hpbar;

    void Start()
    {
        player = GameObject.Find("Player");
        player_status = player.GetComponent<Player_Status>();
    }

    void Update()
    {
        Expbar.value = player_status.Current_Exp / (100 + (player_status.Full_Exp * 100));

        if(player_status.Hp != 0)
        {
            Hpbar.value = player_status.Current_Hp / player_status.Hp;
        }
    }
}

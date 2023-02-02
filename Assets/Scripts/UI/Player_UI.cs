using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
        Hpbar.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, gameObject.transform.position.y + 45);
        Expbar.value = player_status.Current_Exp / (100 + (player_status.Full_Exp * 100));
        GameObject.Find("Level").GetComponent<TextMeshProUGUI>().text = "LEVEL : " + player_status.Full_Exp.ToString();

        if(player_status.Current_Hp != 0)
        {
            Hpbar.value = player_status.Current_Hp / player_status.HP;
        }
    }
}

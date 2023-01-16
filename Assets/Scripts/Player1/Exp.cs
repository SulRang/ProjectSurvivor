using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    public int Exp_1 = 10;
    Player_Status player_status;
    GameObject player;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("°æÇèÄ¡ È¹µæ");
        player_status.Current_Exp += Exp_1 * player_status.Exp_Gain_Rate; // °æÇèÄ¡ È¹µæ·®(1.0 ~ 2.0) * Exp_1
        Debug.Log(player_status.Current_Exp);
        Destroy(gameObject);
    }
    private void Start()
    {
        player = GameObject.Find("Player");
        player_status = player.GetComponent<Player_Status>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    [SerializeField]
    public int Exp_1;
    Player_Status player_status;
    GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player_status.Current_Exp += Exp_1 * player_status.Exp_Gain_Rate; // °æÇèÄ¡ È¹µæ·®(1.0 ~ 2.0) * Exp_1
            Player_Status.instance.UpgradeStatus("Hp", 1);
            player_status.StatusUpdate();
            player_status.ExpCheck();
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        player = GameObject.Find("Player");
        player_status = player.GetComponent<Player_Status>();
    }
}

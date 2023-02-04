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
        if (collision.gameObject.tag == "Exp")
        {
            player_status.Current_Exp += Exp_1 * player_status.EXP_GAIN_RATE; // ����ġ ȹ�淮(1.0 ~ 2.0) * Exp_1
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

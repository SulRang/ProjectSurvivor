using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessoryGoldPacket : MonoBehaviour
{
    Player_Status player;

    public int Upgrade = 1;

    // Start is called before the first frame update
    void Start()
    {
        player.UpgradeStatus("Gold_Gain_Rate", Upgrade);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

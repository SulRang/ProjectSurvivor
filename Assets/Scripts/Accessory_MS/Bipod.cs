using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bipod : Accessory
{
    bool isActive = false;
    // Update is called once per frame
    void Update()
    {
        AccessoryEffect();
    }

    public void AccessoryEffect()
    {
        string state = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Move>().GetState();
        if (state == "PlayerIdle")
        {
            if (!isActive)
            {
                Player_Status.instance.UpgradeStatus(statusName, statusValue);
                isActive = true;
            }
        }
        else
        {
            if (isActive)
            {
                Player_Status.instance.UpgradeStatus(statusName, -statusValue);
                isActive = false;
            }
        }

    }
}

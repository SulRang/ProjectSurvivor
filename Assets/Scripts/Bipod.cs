using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bipod : Accessory
{
    bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
                Debug.Log("Speed");
                Player_Status.instance.UpgradeStatus(statusName, statusValue);
                isActive = true;
            }
        }
        else
        {
            if (isActive)
            {
                Debug.Log("Speed22");
                Player_Status.instance.UpgradeStatus(statusName, -statusValue);
                isActive = false;
            }
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWeapon : MonoBehaviour
{
    public GameObject T;
    Player_Status playerStatus;
    ShowRandomItem showRandomItem;

    // Start is called before the first frame update
    void Start()
    {
        playerStatus = gameObject.GetComponent<Player_Status>();
        showRandomItem = T.GetComponent<ShowRandomItem>();

        showRandomItem.StartLevel = true;
        playerStatus.Full_Exp++;
    }
}

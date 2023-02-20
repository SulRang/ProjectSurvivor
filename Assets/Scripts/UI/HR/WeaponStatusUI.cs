using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponStatusUI : MonoBehaviour
{
    Player_Status playerStatus;
    ShowRandomItem showItem;

    // Start is called before the first frame update
    void Start()
    {
        playerStatus = GameObject.Find("Player").GetComponent<Player_Status>();
        showItem = GameObject.Find("MainLevelUp").GetComponentInChildren<ShowRandomItem>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < playerStatus.weaponSet.Count; i++)
        {
            //Debug.Log(playerStatus.weaponSet.Count);
            gameObject.GetComponentsInChildren<TextMeshProUGUI>()[i].text = playerStatus.weaponSet[i];

            foreach (var item in showItem.Data)
            {
                //Debug.Log(item[1] + "," + playerStatus.weaponSet[i] + "," + item[2]);
                Debug.Log(item[1] == playerStatus.weaponSet[i]);
                if(playerStatus.weaponSet[i] == item[1])
                {
                    //Debug.Log((int.Parse(item[2]) / 5f) + "       dddddddddddddddddddddddddddddd");
                    gameObject.GetComponentsInChildren<Slider>()[i].value = int.Parse(item[2]) / 5f;
                }
            }
        }
    }
}
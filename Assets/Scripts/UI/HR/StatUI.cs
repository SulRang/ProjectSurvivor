using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;

public class StatUI : MonoBehaviour
{
    Player_Status playerStatus;

    // Start is called before the first frame update
    void Start()
    {
        playerStatus = GameObject.Find("Player").gameObject.GetComponent<Player_Status>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("HpStat").GetComponent<TextMeshProUGUI>().text = playerStatus.HP.ToString();
        GameObject.Find("RegenStat").GetComponent<TextMeshProUGUI>().text = playerStatus.REGENERATION.ToString();
        GameObject.Find("DfStat").GetComponent<TextMeshProUGUI>().text = playerStatus.DEF.ToString();
        GameObject.Find("SpStat").GetComponent<TextMeshProUGUI>().text = playerStatus.SPEED.ToString();
        GameObject.Find("DmgStat").GetComponent<TextMeshProUGUI>().text = playerStatus.DMG.ToString();
        GameObject.Find("CoolStat").GetComponent<TextMeshProUGUI>().text = playerStatus.COOLDOWN.ToString();
        GameObject.Find("DurationStat").GetComponent<TextMeshProUGUI>().text = playerStatus.DURATION.ToString();
        GameObject.Find("CountStat").GetComponent<TextMeshProUGUI>().text = playerStatus.PROJECTILE_COUNT.ToString();
        GameObject.Find("MgStat").GetComponent<TextMeshProUGUI>().text = playerStatus.MAGNET.ToString();
        GameObject.Find("CritStat").GetComponent<TextMeshProUGUI>().text = playerStatus.CRITICAL.ToString();
        GameObject.Find("CritDmgStat").GetComponent<TextMeshProUGUI>().text = playerStatus.CRITICAL_DMG.ToString();
        GameObject.Find("ExpStat").GetComponent<TextMeshProUGUI>().text = playerStatus.EXP_GAIN_RATE.ToString();
        GameObject.Find("GoldStat").GetComponent<TextMeshProUGUI>().text = playerStatus.GOLD_GAIN_RATE.ToString();

    }
}

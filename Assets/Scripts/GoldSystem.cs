using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldSystem : MonoBehaviour
{
    [SerializeField]
    Text minuteText;

    private static int gold = 100;

    //½Ì±ÛÅæ
    public static GoldSystem instance_gold;
    public static GoldSystem Instance_Gold
    {
        get
        {
            if (instance_gold == null)
            {
                instance_gold = FindObjectOfType(typeof(GoldSystem)) as GoldSystem;
            }

            return instance_gold;
        }
    }

    private void Awake()
    {
        if (instance_gold == null)
        {
            instance_gold = this;
        }
        else if (instance_gold != this)
        {
            Destroy(gameObject);
        }
    }

    public int GetGold()
    {
        return gold;
    }

    public void SetGold(int _gold)
    {
        gold += _gold;
    }

    public int CalGold(int _gold)
    {
        int min = int.Parse(minuteText.text);
        int cal_gold = 0;

        if (min >= 10 && min < 20)
        {
            cal_gold = (int)((_gold / 5000) * Player_Status.instance.GOLD_GAIN_RATE);
        }
        else if (min >= 20)
        {
            cal_gold = (int)((_gold / 10000) * Player_Status.instance.GOLD_GAIN_RATE);
        }
        else
        {
            cal_gold = (int)((_gold / 1000) * Player_Status.instance.GOLD_GAIN_RATE);
        }
        return cal_gold;
    }
}

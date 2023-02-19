using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldSystem : MonoBehaviour
{
    private static int gold = 100;

    //ΩÃ±€≈Ê
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetGold()
    {
        return gold;
    }

    public void SetGold(int _gold)
    {
        gold += _gold;
    }
}

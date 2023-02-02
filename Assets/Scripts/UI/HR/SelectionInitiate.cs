using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectionInitiate : MonoBehaviour
{
    ShowRandomItem showItem;
    // Start is called before the first frame update
    void Start()
    {
        showItem = gameObject.GetComponentInParent<ShowRandomItem>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(gameObject.name)
        {
            case "FirstSelection":
                transform.Find("ItemName").GetComponent<TextMeshProUGUI>().text = showItem.FirstItem;
                transform.Find("ItemLevel").GetComponent<TextMeshProUGUI>().text = showItem.FirstItemLevel;
                transform.Find("ItemExplain").GetComponent<TextMeshProUGUI>().text = showItem.FirstItemExplain;
                break;
            case "SecondSelection":
                transform.Find("ItemName").GetComponent<TextMeshProUGUI>().text = showItem.SecondItem;
                transform.Find("ItemLevel").GetComponent<TextMeshProUGUI>().text = showItem.SecondItemLevel;
                transform.Find("ItemExplain").GetComponent<TextMeshProUGUI>().text = showItem.SecondItemExplain;
                break;
            case "ThirdSelection":
                transform.Find("ItemName").GetComponent<TextMeshProUGUI>().text = showItem.ThirdItem;
                transform.Find("ItemLevel").GetComponent<TextMeshProUGUI>().text = showItem.ThirdItemLevel;
                transform.Find("ItemExplain").GetComponent<TextMeshProUGUI>().text = showItem.ThirdItemExplain;
                break;
            
        }
    }
}

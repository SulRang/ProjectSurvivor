using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class UpgradeShopManager : MonoBehaviour
{
    GameObject selectedElement;

    [SerializeField]
    GameObject parentElement;

    [SerializeField]
    TMP_Text goldText;
    int gold = 0;
    
    Dictionary<string, float> statusDict;

    // Start is called before the first frame update
    void Start()
    {
        gold = GoldSystem.instance_gold.GetGold();
        goldText.text = gold + "G";
        statusDict = new Dictionary<string, float>();
    }

    // Update is called once per frame
    void Update()
    {
        gold = GoldSystem.instance_gold.GetGold();
        goldText.text = gold + "G";
    }
    public void SelectElement()
    {
        selectedElement = EventSystem.current.currentSelectedGameObject;
    }

    public void Upgrade()
    {
        //Debug.Log(selectedElement.transform.GetChild(1));
        string statusName = selectedElement.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text;
        string statusLevelStr = selectedElement.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text;
        float statusLevel = float.Parse(statusLevelStr);
        if(statusLevel == 5)
        {
            return;
        }
        statusLevel++;
        GoldSystem.instance_gold.SetGold(-10 * (int)statusLevel);
        selectedElement.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = statusLevel.ToString();
        if (statusDict.ContainsKey(statusName))
        {
            statusDict[statusName] = statusLevel;
        }
        else
        {
            statusDict.Add(statusName, statusLevel);
        }
    }

    public void UpdateText()
    {
        Transform[] allElements = parentElement.GetComponentsInChildren<Transform>();
        foreach(Transform child in allElements)
        {
            if (child.name.Contains("Element"))
            {
                string statusName = child.transform.GetChild(1).name;
                float statusLevel;
                statusDict.TryGetValue(statusName, out statusLevel);
                child.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = statusLevel.ToString();
            }
        }

    }

    public void UpdateUpgrade()
    {
        foreach(KeyValuePair<string, float> statusData in statusDict)
        {
            Player_Status.instance.UpgradeStatus(statusData.Key, statusData.Value);
        }
    }

    public void ResetUpgrade()
    {
        List<string> statusList = new List<string>();
        foreach(KeyValuePair<string, float> statusData in statusDict )
        {
            statusList.Add(statusData.Key);
        }
        for (int i = 0; i < statusDict.Count; i++)
        {
            statusDict[statusList[i]] = 0;
        }
        UpdateText();
    }
}

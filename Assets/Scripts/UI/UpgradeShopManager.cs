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
    TMP_Text goldText;
    int gold = 100;

    // Start is called before the first frame update
    void Start()
    {
        goldText.text = gold.ToString() + "G";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SelectElement()
    {
        selectedElement = EventSystem.current.currentSelectedGameObject;
    }

    public void Upgrade()
    {
        Debug.Log(selectedElement);
    }
}

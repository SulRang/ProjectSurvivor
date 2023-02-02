using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusTransform : MonoBehaviour
{
    RectTransform rectTransform;
    Resolution resolution;

    private void Start()
    {
        resolution = gameObject.GetComponentInParent<Resolution>();
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(resolution.MainStatusWidth, resolution.MainStatusHeight);
        rectTransform.anchoredPosition = new Vector2((resolution.MainStatusWidth / 2) + 10, 
                                                    ((-1) * resolution.MainStatusHeight / 2) - 30);
        foreach(RectTransform i in gameObject.GetComponentsInChildren<RectTransform>())
        {
            if(i.name == "Status")
            {
                i.sizeDelta = new Vector2(resolution.MainStatusWidth, resolution.MainStatusHeight - 100);
                i.anchoredPosition = new Vector2(0, ((-1) * resolution.MainStatusHeight / 2) - 50);
            }
        }
        
    }
}

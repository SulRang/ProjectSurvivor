using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolution : MonoBehaviour
{
    [SerializeField]
    public int MainStatusWidth;

    [SerializeField]
    public int MainStatusHeight;

    // Update is called once per frame
    void Update()
    {
        MainStatusWidth = (int)(gameObject.GetComponent<RectTransform>().rect.width / 4);
        MainStatusHeight = (int)gameObject.GetComponent<RectTransform>().rect.height - 50;
    }
}

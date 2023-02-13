using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    Text[] texts;

    float time;

    bool isEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        texts[0].text = ((int)time / 60 % 60).ToString();
        texts[1].text = ((int)time % 60).ToString();
    }

    public bool ClearCheck()
    {
        if (texts[0].text == "20" && !isEnd)
        {
            isEnd = true;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void InitTrigger()
    {
        isEnd = false;
    }
}

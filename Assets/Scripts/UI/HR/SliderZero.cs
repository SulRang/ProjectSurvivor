using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderZero : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponentInParent<Slider>().value == 0f)
        {
            gameObject.transform.Find("Fill").gameObject.SetActive(false);
        }
        else
        {
            gameObject.transform.Find("Fill").gameObject.SetActive(true);
        }
    }
}

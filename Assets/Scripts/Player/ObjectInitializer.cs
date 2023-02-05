using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInitializer : MonoBehaviour
{

    public void RotationInit()
    {
        if (this.gameObject.transform.eulerAngles.y == 180)
        {
            this.gameObject.transform.eulerAngles = Vector3.zero;
        }
    }
}

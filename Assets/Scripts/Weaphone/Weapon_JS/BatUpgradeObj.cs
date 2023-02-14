using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatUpgradeObj : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0f, 0f, 200f * Time.deltaTime);
    }
}

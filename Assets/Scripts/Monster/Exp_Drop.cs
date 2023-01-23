using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp_Drop : MonoBehaviour
{
    public GameObject EXP;
    private void OnDestroy()
    {
        Instantiate(EXP);
    }
}

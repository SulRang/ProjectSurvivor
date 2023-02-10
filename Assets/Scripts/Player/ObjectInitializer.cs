using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInitializer : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    private void Update()
    {
        gameObject.transform.position = player.transform.position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepositionScanner : MonoBehaviour
{
    // 위 : 0, 아래 : 1, 오른쪽 : 2, 왼쪽 : 3
    [SerializeField]
    int _index;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Monster")
            collision.GetComponent<Monster>().RePositinon(_index);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepositionScanner : MonoBehaviour
{
    // �� : 0, �Ʒ� : 1, ������ : 2, ���� : 3
    [SerializeField]
    int _index;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Monster")
            collision.GetComponent<Monster>().RePositinon(_index);
    }


}

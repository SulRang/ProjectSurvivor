using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAuraUpgrade : MonoBehaviour
{
    [SerializeField]
    float damage = 1f;

    private void Start()
    {
        damage *= Player_Status.instance.DMG;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            collision.GetComponent<Monster>().GetDamage((int)damage);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            collision.GetComponent<Monster>().GetDamage((int)damage);
        }
    }
}

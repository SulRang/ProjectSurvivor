using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAuraUpgrade : Projectile
{
    protected override void Start()
    {
        damage *= Player_Status.instance.DMG;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            Attack(collision);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            Attack(collision);
        }
    }
}

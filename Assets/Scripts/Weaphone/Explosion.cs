using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : Projectile
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Monster")
        {
            collision.GetComponent<Monster>().GetDamage((int)Player_Status.instance.DMG);
        }
    }
}

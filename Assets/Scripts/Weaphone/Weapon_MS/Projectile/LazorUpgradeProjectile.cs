using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazorUpgradeProjectile : Projectile
{
    GameObject target;
    private void Update()
    {
        if (!transform.parent.gameObject.activeInHierarchy)
            Destroy(gameObject);
        else
        {
            curTime += Time.deltaTime;
            if (curTime > 1.0f)
            {
                transform.parent.GetComponent<Monster>().GetDamage((int)damage);
                curTime -= 1.0f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            target = collision.gameObject;
        }
    }
}

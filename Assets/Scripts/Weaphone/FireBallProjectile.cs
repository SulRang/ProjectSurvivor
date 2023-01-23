using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallProjectile : Projectile
{
    [SerializeField]
    GameObject ExplosionObj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            OnHitMonster();
        }
    }

    private void OnHitMonster()
    {
        GameObject Explosion = Instantiate(ExplosionObj, transform);
        Explosion.transform.parent = null;
        Destroy(gameObject);
    }
}

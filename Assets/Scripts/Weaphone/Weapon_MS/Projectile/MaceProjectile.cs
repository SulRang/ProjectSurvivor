using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaceProjectile : Projectile
{
    [SerializeField]
    GameObject maceQuake;
    bool isUpgrade = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            if(isUpgrade)
                OnHitMonster(collision.transform);
            collision.GetComponent<Rigidbody2D>().AddForce((collision.transform.position - transform.position).normalized * power, ForceMode2D.Impulse);
            collision.GetComponent<Monster>().GetDamage(damage);
        }
    }

    private void OnHitMonster(Transform pos)
    {
        GameObject quake = Instantiate(maceQuake, pos);
        quake.transform.parent = null;
    }

    public void Upgrade()
    {
        isUpgrade = true;
    }
}

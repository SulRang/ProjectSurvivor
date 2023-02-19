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
            Attack(collision);
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

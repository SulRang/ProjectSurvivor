using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallFireBallProjectile : Projectile
{
    [SerializeField]
    GameObject ExplosionObj;

    private void Update()
    {
        curTime += Time.deltaTime;
        if (curTime > duration)
            OnHit();
    }

    private void OnHit()
    {
        GameObject Explosion = Instantiate(ExplosionObj, transform);
        Explosion.transform.parent = null;
        Explosion.GetComponent<Projectile>().SetSize(0.5f);
        Destroy(gameObject);
    }
}

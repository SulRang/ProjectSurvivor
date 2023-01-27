using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombProjectile : Projectile_JS
{
    [SerializeField]
    public float _setDuration = 2.0f;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        SetDuration(_setDuration);
    }
}

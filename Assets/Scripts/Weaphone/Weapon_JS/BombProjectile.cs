using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombProjectile : Projectile
{
    [SerializeField]
    public float _setDuration = 1.8f;

    [SerializeField]
    public GameObject explosionObj;

    protected override void Start()
    {
        base.Start();
        SetDuration(_setDuration - Player_Status.instance.RANGE);
        Invoke("explosion", _setDuration - 0.2f);
    }

    void explosion()
    {
        explosionObj.SetActive(true);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

}

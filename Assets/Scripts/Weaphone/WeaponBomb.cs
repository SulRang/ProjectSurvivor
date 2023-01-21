using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBomb : Weaphone
{
    [SerializeField]
    int level = 1;

    [SerializeField]
    GameObject explosionPrefab;

    [SerializeField]
    Vector3 addScale;

    GameObject explosionObject;

    protected override void Start()
    {
        base.Start();
        SetSpeed(0f);
        SetCoolDown(7f - level);
    }
    public override void Attack()
    {
        SetCoolDown(7f - level);

        GameObject projectileObject = Instantiate(projectile, transform);

        projectileObject.transform.parent = null;
        projectileObject.SetActive(true);
        explosionObject = Instantiate(explosionPrefab, projectileObject.transform);
        explosionObject.transform.SetParent(projectileObject.transform);
        explosionObject.SetActive(false);

        float _setDuration = 2.0f;
        projectileObject.GetComponent<Projectile>().SetDuration(2.0f);

        Invoke("explosion", _setDuration - 0.5f);
    }

    void explosion()
    {
        explosionObject.SetActive(true);
    }

}

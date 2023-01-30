using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonUpgradeProjectile : Weaphone
{
    float radius = 10f;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        //투사체 개수
        SetSpeed(200.0f);
        //공격 쿨다운
        SetCoolDown(2.0f);
    }

    public override void Attack()
    {
        if (projectile == null)
            return;

        Collider2D[] Cols;
        Cols = Physics2D.OverlapCircleAll(transform.position, radius);

        for (int i = 0; i < Cols.Length; i++)
        {
            if (Cols[i].tag == "Monster")
            {
                GameObject CannonObject = Instantiate(projectile, Cols[i].transform);

                CannonObject.transform.parent = null;
                CannonObject.SetActive(true);

                CannonObject.GetComponent<Projectile>().SetDuration(0.5f);

                break;
            }
        }
    }
}

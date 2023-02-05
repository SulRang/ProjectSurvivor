using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaphoneDagger : Weaphone
{
    float level = 0;
    public static Vector3 Direction; //대거 방향
    static int Radius = 8;

    public Collider2D[] Cols;

    protected override void Start()
    {
        base.Start();
        //공격 쿨다운
        SetCoolDown(2.0f);
    }

    public void LevelUp()
    {
        ++level;
    }

    public override void Attack()
    {
        if (projectile == null)
            return;
        Vector3 interV;

        Cols = Physics2D.OverlapCircleAll(transform.position, Radius);

        for (int i = 0; i < Cols.Length; i++)
        {
            if (Cols[i].tag == "Monster")
            {
                interV = Cols[i].transform.position - transform.position;
                float theta = Mathf.Acos(interV.normalized.x);
                float degree = interV.normalized.y > 0 ? Mathf.Rad2Deg * theta : Mathf.Rad2Deg * theta * (-1);

                GameObject LazerObject = Instantiate(projectile,
                    new Vector3(transform.position.x, transform.position.y, transform.position.z),
                    Quaternion.Euler(interV.normalized));

                LazerObject.transform.parent = null;
                LazerObject.SetActive(true);

                LazerObject.GetComponentInChildren<Projectile>().SetDuration(2.0f);

                LazerObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, degree));
                LazerObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(interV.normalized.x, interV.normalized.y) * 500);
                break;
            }
        }
    }
}

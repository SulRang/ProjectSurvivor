using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBat : Weaphone
{
    [SerializeField]
    float xPos = 0.95f;

    [SerializeField]
    int level = 1;

    protected override void Start()
    {
        base.Start();
        SetProjectileNum(level);
        SetSpeed(50.0f);
        SetCoolDown(2.0f);
    }

    public override void Attack()
    {
        for (int i = 0; i < level; i++)
        {
            Transform target = transform.parent.GetComponent<WeaphoneCenter>().GetRandomTarget();
            if (projectile == null)
                return;
            if (target == null)
                return;

            Vector3 targetPos = target.position + new Vector3(0, 1, 0);

            GameObject ProjectileObject = Instantiate(projectile, transform.position, Quaternion.identity);
            ProjectileObject.transform.parent = null;
            ProjectileObject.SetActive(true);

            ProjectileObject.GetComponent<Projectile>().SetDuration(2.0f);
            ProjectileObject.transform.Rotate(new Vector3(0, 0, Quaternion.FromToRotation(Vector3.up, targetPos - transform.position).eulerAngles.z));
            ProjectileObject.GetComponent<Rigidbody2D>().AddForce((targetPos - transform.position).normalized * 10 * speed);
        }



    }

    private void Update()
    {
        //오브젝트 회전
        if (Player_Move_JS.Right)
        {
            transform.position = new Vector2(GetComponentInParent<WeaphoneCenter_JS>().GetPlayerPos().position.x - xPos, transform.position.y);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.position = new Vector2(GetComponentInParent<WeaphoneCenter_JS>().GetPlayerPos().position.x + xPos, transform.position.y);
            transform.rotation = Quaternion.Euler(0, 180f, 0);
        }

    }
}

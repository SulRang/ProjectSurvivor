using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponArrow : Weaphone
{
    [SerializeField]
    int level = 1;

    protected override void Start()
    {
        base.Start();
        SetProjectileNum(level + Player_Status.instance.PROJECTILE_COUNT);
        SetCoolDown(2.5f * (1.0f - Player_Status.instance.COOLDOWN));
        SetSpeed(300.0f);
    }

    void LevelUp()
    {
        ++level;
        SetProjectileNum(++projectileNum);
    }

    public override void Attack()
    {
        GameObject[] arrows = new GameObject[level];
        GameObject arrowParent = new GameObject("arrowParent");
        arrowParent.transform.position = transform.position;
        arrowParent.transform.parent = null;
        arrowParent.SetActive(true);

        for (int i = 0; i < projectileNum; i++)
        {
            arrows[i] = Instantiate(projectile, transform.position + new Vector3(0.3f , i * 0.2f, 0f), Quaternion.identity);

            arrows[i].transform.SetParent(arrowParent.transform);
            arrows[i].SetActive(true);
            
            arrows[i].GetComponent<Projectile>().SetDuration(2.0f);
        }

        Destroy(arrowParent, 2.0f);
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 playerToward = new Vector2(horizontal, vertical).normalized;
        Vector2 forceVector;

        //오브젝트 회전
        if (playerToward == new Vector2(-1f, 0f))
        {
            arrowParent.transform.Rotate(0, 0, Quaternion.FromToRotation(Vector3.right, playerToward).eulerAngles.y);
            forceVector = playerToward;
        }
        else if (playerToward == Vector2.zero)
        {
            arrowParent.transform.Rotate(0, (Player_Move.Right) ? 0 : 180, 0);
            
            forceVector = (Player_Move.Right) ? Vector2.right : Vector3.left;
        }
        else
        {
            arrowParent.transform.Rotate(0, 0, Quaternion.FromToRotation(Vector3.right, playerToward).eulerAngles.z);
            forceVector = playerToward;
        }

        for (int i = 0; i < level; i++)
        {
            arrows[i].GetComponent<Rigidbody2D>().AddForce(forceVector * speed);
        }
    }
}

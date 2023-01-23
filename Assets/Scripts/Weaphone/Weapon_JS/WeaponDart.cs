using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDart : Weaphone
{
    [SerializeField]
    int level = 1;

    protected override void Start()
    {
        base.Start();
        SetCoolDown(1.0f);
        SetSpeed(300.0f);
    }

    void LevelUp()
    {
        ++level;
    }

    public override void Attack()
    {
        GameObject[] darts = new GameObject[level];
        GameObject dartParent = new GameObject("dartParent");
        dartParent.transform.position = transform.position;
        dartParent.transform.parent = null;
        dartParent.SetActive(true);

        int angle = (level - 1) * 20; // 0 20 40 60 80 
        int oneDegree = angle / level;
        int half = angle / 2;

        // 투사체 생성
        for (int i = 0; i < level; i++)
        {
            darts[i] = Instantiate(projectile, transform.position + new Vector3(0.3f, i * 0.2f, 0f), Quaternion.identity);

            darts[i].transform.SetParent(dartParent.transform);
            darts[i].SetActive(true);

            darts[i].GetComponent<Projectile>().SetDuration(2.0f);
        }

        Destroy(dartParent, 2.0f);
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 playerToward = new Vector2(horizontal, vertical).normalized;
        Vector2 forceVector;

        //오브젝트 회전
        if (playerToward == new Vector2(-1f, 0f))
        {
            dartParent.transform.Rotate(0, 0, Quaternion.FromToRotation(Vector3.right, playerToward).eulerAngles.y);
            forceVector = playerToward;
        }
        else if (playerToward == Vector2.zero)
        {
            dartParent.transform.Rotate(0, (Player_Move.Right) ? 0 : 180, 0);

            forceVector = (Player_Move.Right) ? Vector3.right : Vector3.left;
        }
        else
        {
            dartParent.transform.Rotate(0, 0, Quaternion.FromToRotation(Vector3.right, playerToward).eulerAngles.z);
            forceVector = playerToward;
        }

        int cal_Angle = half;

        //방사형 각도 
        if (level <= 2)
        {
            for (int i = 0; i < level; i++)
            {
                cal_Angle -= (i * angle);
                darts[i].GetComponent<Rigidbody2D>().AddForce(Quaternion.AngleAxis(cal_Angle, Vector3.forward) * forceVector * speed);
            }
        }
        else
        {
            for (int i = 0; i < level; i++)
            {
                cal_Angle -= oneDegree;
                Debug.Log(cal_Angle);
                darts[i].GetComponent<Rigidbody2D>().AddForce(Quaternion.AngleAxis(cal_Angle, Vector3.forward) * forceVector * speed);
            }
        }
    }
}

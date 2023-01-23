using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaphoneLazer : Weaphone
{
    public static Vector3 Direction; //레이저 방향
    public Transform Target;
    static int Range = 60;
    static int Radius = 8;

    public Collider2D[] Cols;

    void Direction_Check()
    {
        float Hor;
        float Ver;

        Hor = Player_Move.playerMove.Horizontal;
        Ver = Player_Move.playerMove.Vertical;

        //키보드 입력 체크
        if (Hor > 0)
        {
            if (Ver > 0) // 우상
            {
                Direction = new Vector3(0.71f, 0.71f, 0);
            }
            else if (Ver < 0) // 우하
            {
                Direction = new Vector3(0.71f, -0.71f, 0);
            }
            else // 우
            {
                Direction = new Vector3(1f, 0, 0);
            }
        }
        else if (Hor < 0)
        {
            if (Ver > 0) // 좌상
            {
                Direction = new Vector3(-0.71f, 0.71f, 0);
            }
            else if (Ver < 0) // 좌하
            {
                Direction = new Vector3(-0.71f, -0.71f, 0);
            }
            else // 좌
            {
                Direction = new Vector3(-1f, 0, 0);
            }
        }
        else // x축 정지
        {
            if (Ver > 0) // 상
            {
                Direction = new Vector3(0, 1f, 0);
            }
            else if (Ver < 0) // 하
            {
                Direction = new Vector3(0, -1f, 0);
            }
            else  //정지
            {
            }
        }
    }

    protected override void Start()
    {
        base.Start();
        //공격 쿨다운
        SetCoolDown(2.0f);
    }

    public override void Attack()
    {
        if (projectile == null)
            return;
        Vector3 interV;

        Cols = Physics2D.OverlapCircleAll(transform.position, Radius);

        Direction_Check();

        for (int i = 0; i < Cols.Length; i++)
        {
            if (Cols[i].tag == "Monster")
            {
                interV = Cols[i].transform.position - transform.position;
                float dot = Vector3.Dot(interV.normalized, Direction);
                float theta = Mathf.Acos(dot);
                float degree = Mathf.Rad2Deg * theta;

                if (degree <= Range / 2)
                {
                    Debug.Log(interV.normalized);
                    GameObject LazerObject = Instantiate(projectile, 
                        new Vector3(transform.position.x, transform.position.y, transform.position.z), 
                        Quaternion.Euler(interV.normalized));
                    LazerObject.transform.parent = null;
                    LazerObject.SetActive(true);
                    LazerObject.GetComponentInChildren<Projectile>().SetDuration(1.0f);

                    theta = Mathf.Acos(interV.normalized.x);
                    degree = interV.normalized.y > 0 ? Mathf.Rad2Deg * theta : Mathf.Rad2Deg * theta * (-1);
                    LazerObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, degree));
                    LazerObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(interV.normalized.x, interV.normalized.y) * 500);
                    break;
                }
            }
        }
    }
}

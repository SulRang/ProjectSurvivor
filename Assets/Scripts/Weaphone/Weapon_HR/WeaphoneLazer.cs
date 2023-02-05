using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaphoneLazer : Weaphone
{
    public static Vector3 Direction; //레이저 방향
    public Transform Target;
    static int Range = 60;
    static int Radius = 8;
    [SerializeField]
    bool isUpgrade = false;
    [SerializeField]
    bool isClass = false;
    [SerializeField]
    GameObject classProjectile;
    public Collider2D[] Cols;
    float count = 0;

    float StartTime = 2.0f;
    int level = 0;

    public void LevelUp()
    {
        StartTime += 0.5f;
        SetCoolDown(StartTime);
        level++;
        Debug.Log("레벨업 하였습니다. LV : " + level);
    }

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
        SetCoolDown(StartTime);
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
                    //Debug.Log(interV.normalized);
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
        if (isUpgrade)
            UpgradeAttack();
        if (isClass)
            ClassAttack();
    }
    void UpgradeAttack()
    {
        for (int i = 0; i < 4; i++)
        {
            //투사체 개수에 따른 각도 설정
            float degree = 45 + 360 / 4 * i;
            float radian = Mathf.Deg2Rad * degree;
            //투사체 생성
            GameObject ProjectileObject = Instantiate(projectile, transform);
            ProjectileObject.transform.localPosition = Vector3.zero;
            ProjectileObject.SetActive(true);
            ProjectileObject.transform.parent = null;
            //투사체 지속시간 설정
            ProjectileObject.GetComponent<Projectile>().SetDuration(1.0f);
            //투사체 각도 및 이동 설정
            ProjectileObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, degree));
            Vector3 dirVec3 = new Vector3(Mathf.Sin(radian), Mathf.Cos(radian));
            ProjectileObject.GetComponent<Rigidbody2D>().AddForce(dirVec3.normalized * 500);

        }
    }
    void ClassAttack()
    {
        count++;
        if (count % 2 == 0)
        {
            count = 0;
            return;
        }
        Transform target = transform.parent.GetComponent<WeaponCenter>().GetRandomTarget();
        if (projectile == null)
            return;
        if (target == null)
            return;
        //타겟 vector 계산 (y 1을 더해야 타겟의 가운데)
        Vector3 targetPos = target.position + new Vector3(0, 1, 0);

        //투사체 생성
        GameObject ProjectileObject = Instantiate(classProjectile, target);
        ProjectileObject.SetActive(true);

        //투사체 지속 시간 설정
        ProjectileObject.GetComponent<Projectile>().SetDuration(8.0f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDart : Weaphone
{
    [SerializeField]
    int level = 1;

    bool isUpgrade = false;

    float upCooltime = 0f;

    [SerializeField]
    float upgradeProjNum = 30;
    [SerializeField]
    int classIdx = 2;
    protected override void Start()
    {
        base.Start();
        SetProjectileNum(level + Player_Status.instance.PROJECTILE_COUNT);
        SetCoolDown(2.0f * (1.0f - Player_Status.instance.COOLDOWN));
        SetSpeed(300.0f);
    }

    public void LevelUp()
    {
        ++level;
        SetProjectileNum(++projectileNum);
        if (level >= 5)
        {
            Upgrade();
        }
    }

    public override void Attack()
    {
        GameObject[] darts = new GameObject[(int)projectileNum];
        GameObject dartParent = new GameObject("dartParent");
        dartParent.transform.position = transform.position;
        dartParent.transform.parent = null;
        dartParent.SetActive(true);

        int angle = ((int)projectileNum - 1) * 20; // 0 20 40 60 80 
        int oneDegree = angle / ((int)projectileNum == 0 ? 1 : (int)projectileNum);
        int half = angle / 2;

        // 투사체 생성
        for (int i = 0; i < projectileNum; i++)
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

            forceVector = (Player_Move.Right) ? Vector2.left : Vector2.right;
        }
        else
        {
            dartParent.transform.Rotate(0, 0, Quaternion.FromToRotation(Vector3.right, playerToward).eulerAngles.z);
            forceVector = playerToward;
        }

        int cal_Angle = half;

        //방사형 각도 
        if (projectileNum <= 2)
        {
            for (int i = 0; i < projectileNum; i++)
            {
                cal_Angle -= (i * angle);
                darts[i].GetComponent<Rigidbody2D>().AddForce(Quaternion.AngleAxis(cal_Angle, Vector3.forward) * forceVector * speed);
            }
        }
        else
        {
            for (int i = 0; i < projectileNum; i++)
            {
                cal_Angle -= oneDegree;
                darts[i].GetComponent<Rigidbody2D>().AddForce(Quaternion.AngleAxis(cal_Angle, Vector3.forward) * forceVector * speed);
            }
        }
    }

    // 표창 전직. 조건은 표창 5레벨 이상. 일정 시간 간격으로 나선형 표창 발사.
    public void Upgrade()
    {
        if (level >= 5 && !Player_Status.instance.HasClass(classIdx))
        {
            isUpgrade = true;
            StartCoroutine(BeforeUpgradeAttackCoroutine());
        }
    }

    // 표창 전직 시 사용 코루틴. 4초 간격으로 나선형 패턴 표창 발사
    IEnumerator BeforeUpgradeAttackCoroutine()
    {
        while (isUpgrade)
        {
            upCooltime += Time.deltaTime;
            if (upCooltime >= 3f)
            {
                upCooltime -= 3f;
                StartCoroutine(UpgradeAttackCoroutine());
                yield return new WaitForSeconds(1f);
            }
            yield return null;
        }
    }

    // 나선 패턴 표창 생성 코루틴.
    IEnumerator UpgradeAttackCoroutine()
    {
        float angle = 360.0f / upgradeProjNum;

        for (int i = 0; i < upgradeProjNum; i++)
        {
            float cal_Angle = angle * i;
            float radian = Mathf.Deg2Rad * cal_Angle;
            GameObject upProj = Instantiate(projectile, transform);
            upProj.GetComponent<Rigidbody2D>().AddForce(new Vector2(300f * Mathf.Sin(radian), 300f * Mathf.Cos(radian)));
            yield return new WaitForSeconds(0.01f);
        }
    }
}

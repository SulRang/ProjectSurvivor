using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaphoneDaggerUpgrade : Weaphone
{
    public static Vector3 Direction; //대거 방향
    static int Radius = 8;

    [SerializeField]
    bool isUpgrade = false;

    [SerializeField]
    bool isClass = false;

    [SerializeField]
    GameObject upgradProjectile;

    [SerializeField]
    GameObject accessory;

    public Collider2D[] Cols;
    int stackCount = 0;
    int level = 1;

    [SerializeField]
    int classIdx = 5;
    

    protected override void Start()
    {
        base.Start();
    }

    public void LevelUp()
    {
        level++;
    }


    public override void Attack()
    {
        if (projectile == null)
            return;
        BasicAttack();

        if (isUpgrade)
            UpgradeAttack();

        if (isClass)
            ClassAttack();
    }

    void BasicAttack()
    {
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
                LazerObject.GetComponent<DaggerTurning>().SetMax(level);
                LazerObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, degree));
                LazerObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(interV.normalized.x, interV.normalized.y) * 500);
                break;
            }
        }

    }

    void UpgradeAttack()
    {
        if (stackCount > 4)
        {
            for (int i = 0; i < 8; i++)
            {
                //투사체 개수에 따른 각도 설정
                float degree = 360 / 8 * i;
                float radian = Mathf.Deg2Rad * degree;
                //투사체 생성
                GameObject LazerObject = Instantiate(projectile, transform);
                LazerObject.SetActive(true);
                LazerObject.transform.parent = null;
                //투사체 지속시간 설정
                LazerObject.GetComponent<Projectile>().SetDuration(2.0f);
                LazerObject.GetComponent<DaggerTurning>().SetMax(level);
                //투사체 각도 및 이동 설정
                LazerObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 90 - degree));
                Vector3 dirVec3 = new Vector3(range * Mathf.Sin(radian), range * Mathf.Cos(radian));
                LazerObject.GetComponent<Rigidbody2D>().AddForce(dirVec3.normalized * 500);
            }
            stackCount = 0;
        }
        else
            stackCount++;

    }

    void ClassAttack()
    {
        if (projectile == null)
            return;
        for (int i = 0; i < projectileNum + level/2; i++)
        {
            //가까운 타겟 Transform 가져오기
            Transform target = transform.parent.GetComponent<WeaponCenter>().GetRandomTarget();

            if (projectile == null)
                return;
            if (target == null)
                return;
            //타겟 vector 계산 (y 0.5f을 더해야 타겟의 가운데)
            Vector3 targetPos = target.position + new Vector3(0, 0.5f, 0);
            //플레이어 -> 타겟 벡터
            Vector3 difVec3 = targetPos - transform.position;

            //투사체 생성
            GameObject ProjectileObject = Instantiate(upgradProjectile, transform);
            //투사체 부모 오브젝트 제거
            ProjectileObject.transform.parent = null;
            ProjectileObject.SetActive(true);

            //투사체 지속 시간 설정
            ProjectileObject.GetComponent<Projectile>().SetDuration(5.0f);
            if (isUpgrade)
                ProjectileObject.GetComponent<CrossbowBoltProjectile>().Upgrade();
            //투사체 타겟 방향으로 각도 설정
            ProjectileObject.transform.Rotate(new Vector3(0, 0, Quaternion.FromToRotation(Vector3.up, difVec3).eulerAngles.z));
            //투사체 타겟 방향으로 이동
            ProjectileObject.GetComponent<Rigidbody2D>().AddForce(difVec3.normalized * 100 * speed);
        }
    }

    public void Upgrade()
    {
        if (!Player_Status.instance.HasClass(classIdx) && !isUpgrade && level >= 5)
        {
            isClass = true;
        }
    }

    public void UpgradeWithAcc()
    {
        if(accessory.GetComponent<ACC_MoneyPocket>().GetLevel() >= 5 && !isClass && level >= 5)
        {
            isUpgrade = true;
        }
    }
}

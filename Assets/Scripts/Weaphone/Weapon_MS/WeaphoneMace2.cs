using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaphoneMace2 : Weaphone
{
    [SerializeField]
    bool isUpgrade = false;
    [SerializeField]
    bool isClass = false;
    [SerializeField]
    GameObject classProjectile;
    [SerializeField]
    GameObject accessory;

    [SerializeField]
    int classIdx = 4;

    public static Vector3 Direction;
    public Transform player;

    GameObject MaceObject;
    bool isTurn = false;
    
    //현재 이동방향 확인 함수
    void Direction_Check()
    {
        float Hor;
        float Ver;

        Hor = Player_Move.playerMove.Horizontal;
        Ver = Player_Move.playerMove.Vertical;

        //키보드 입력 체크
        //철퇴의 시작 지점은 이동 방향과 달라야 하므로 8방위에서 한 칸씩 아래로 민다.
        if (Hor > 0)
        {
            if (Ver > 0) // 우상 -> 상
            {
                Direction = new Vector3(0, 1f, 0);
            }
            else if (Ver < 0) // 우하 -> 우
            {
                Direction = new Vector3(1f, 0f, 0);
            }
            else // 우 -> 우상
            {
                Direction = new Vector3(0.71f, 0.71f, 0);
            }
        }
        else if (Hor < 0)
        {
            if (Ver > 0) // 좌상 -> 좌
            {
                Direction = new Vector3(-1f, 0f, 0);
            }
            else if (Ver < 0) // 좌하 -> 하
            {
                Direction = new Vector3(0f, -1f, 0);
            }
            else // 좌 -> 좌하
            {
                Direction = new Vector3(-0.71f, -0.71f, 0);
            }
        }
        else // x축 정지
        {
            if (Ver > 0) // 상 -> 좌상
            {
                Direction = new Vector3(-0.71f, 0.71f, 0);
            }
            else if (Ver < 0) // 하 -> 우하
            {
                Direction = new Vector3(0.71f, -0.71f, 0);
            }
            else  //정지
            {
            }
        }
    }

    public void LevelUp()
    {
        level++;
        SetProjectileNum(level/2);
        SetCoolDown(3 - level/5f);
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        //투사체 개수
        SetSpeed(200.0f);
    }

    public override void Attack()
    {
        if (projectile == null)
            return;

        Direction_Check();

        float theta = Mathf.Acos(Direction.x);
        float degree = Direction.y > 0 ? Mathf.Rad2Deg * theta : Mathf.Rad2Deg * theta * (-1);
        degree += 80;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, degree));

        //Debug.Log(Direction);
        transform.position = new Vector3(transform.position.x + (Direction.x * 2f), transform.position.y + (Direction.y * 2f));

        //투사체 생성
        MaceObject = Instantiate(projectile, transform);
        //투사체 부모 오브젝트 제거
        MaceObject.transform.parent = null;
        MaceObject.SetActive(true);
        //투사체 지속시간 설정
        MaceObject.GetComponent<Projectile>().SetDuration(0.5f);
        //투사체 방향 및 이동 설정
        MaceObject.GetComponent<Rigidbody>().AddTorque(new Vector3(0,0,1) * 300 * (-1));
        projectile.GetComponent<Projectile>().SetSize(1 + level/2);
        isTurn = true;
        transform.position = player.position;
        transform.rotation = player.rotation;
        if (isUpgrade)
        {
            MaceObject.transform.GetChild(0).GetComponent<MaceProjectile>().Upgrade();
        }
        if (isClass)
            ClassAttack();
    }

    public void ClassAttack()
    {
        if (projectile == null)
            return;
        for (int i = 0; i < projectileNum; i++)
        {
            //투사체 개수에 따른 각도 설정
            float degree = 360.0f / (projectileNum) * i;
            float radian = Mathf.Deg2Rad * degree;
            //투사체 생성
            GameObject projectileObject = Instantiate(classProjectile, transform);
            projectileObject.SetActive(true);
            //투사체 지속시간 설정
            projectileObject.GetComponent<Projectile>().SetDuration(1.0f);
            //투사체 각도 및 이동 설정
            projectileObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -degree));
            projectileObject.transform.localPosition = new Vector3(range * Mathf.Sin(radian), range * Mathf.Cos(radian));
            projectileObject.transform.parent = null;
        }
    }

    private void Update()
    {
        if (isTurn && MaceObject != null)
        {
            MaceObject.transform.RotateAround(player.position, Vector3.back, 200 * Time.deltaTime);
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
        if (accessory.activeSelf && !isClass && level >= 5)
        {
            isUpgrade = true;
        }
    }
}

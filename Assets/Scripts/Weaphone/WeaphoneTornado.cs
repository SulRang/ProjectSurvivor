using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaphoneTornado : Weaphone
{
    /// <summary>
    /// 랜덤한 타겟으로 투사체를 소환하는 무기
    /// </summary>

    [SerializeField]
    int level = 1;

    bool isUpgrade = false;

    [SerializeField]
    GameObject Shoes;

    protected override void Start()
    {
        base.Start();
        //투사체 개수
        SetProjectileNum(1);
        //투사체 속도. 업그레이드 이후 사용됨.
        SetSpeed(300.0f);
        //공격 쿨다운
        SetCoolDown(1.0f);
    }

    public override void Attack()
    {
        //랜덤한 타겟 Transform 가져오기
        Transform target = transform.parent.GetComponent<WeaphoneCenter>().GetRandomTarget();
        if (projectile == null)
            return;
        if (target == null)
            return;
        //타겟 vector 계산 (y 1을 더해야 타겟의 가운데)
        Vector3 targetPos = target.position + new Vector3(0, 1, 0);

        //투사체 생성
        GameObject ProjectileObject = Instantiate(projectile, target);
        //투사체 부모 오브젝트 제거
        ProjectileObject.transform.parent = null;
        ProjectileObject.SetActive(true);

        //투사체 지속 시간 설정
        ProjectileObject.GetComponent<Projectile>().SetDuration(1.0f);

        Vector2 moveVec = new Vector2(0f, 0f);

        // 업그레이드 시 토네이도 이동방향 설정
        if (isUpgrade)
        {
            moveVec = SetMoveVec();
            ProjectileObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(moveVec.x * speed, moveVec.y * speed));
        }
    }

    public void LevelUp()
    {
        ++level;
    }

    // 부채 업그레이드. 조건은 신발과 부채 모두 5레벨 이상. 생성되는 토네이도가 랜덤(상하좌우 중)하게 이동
    public void Upgrade()
    {
        if (Shoes.GetComponent<ACC_Shoes>().GetLevel() >= 5 && level >= 5)
        {
            isUpgrade = true;
        }
    }

    // 랜덤 이동방향 지정
    Vector2 SetMoveVec()
    {
        int dir_Index = Random.Range(0, 4);
        Vector2 _moveVec = new Vector2();
        switch (dir_Index)
        {
            //위
            case 0:
                _moveVec = Vector2.up;
                break;

            //아래
            case 1:
                _moveVec = Vector2.down;
                break;

            //오른쪽
            case 2:
                _moveVec = Vector2.right;
                break;

            case 3:
                _moveVec = Vector2.left;
                break;
        }

        return _moveVec;
    }
}

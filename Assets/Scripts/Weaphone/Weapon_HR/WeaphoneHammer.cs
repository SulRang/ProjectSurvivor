using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaphoneHammer : Weaphone
{
    float level = 0;

    public static Vector3 Direction;
    public Transform player;

    GameObject MaceObject;
    bool isTurn = false;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        //투사체 개수
        SetSpeed(200.0f);
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

        float theta = Mathf.Acos(Direction.x);
        float degree = Direction.y > 0 ? Mathf.Rad2Deg * theta : Mathf.Rad2Deg * theta * (-1);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, degree));

        //Debug.Log(Direction);
        transform.position = new Vector3(transform.position.x + 1, transform.position.y + 1);

        //투사체 생성
        MaceObject = Instantiate(projectile, transform);
        //투사체 부모 오브젝트 제거
        MaceObject.transform.parent = null;
        MaceObject.SetActive(true);
        //투사체 지속시간 설정
        MaceObject.GetComponent<Projectile>().SetDuration(0.5f);
        //투사체 방향 및 이동 설정
        //MaceObject.GetComponent<Rigidbody>().AddTorque(new Vector3(0, 0, 1) * 300 * (-1));
        isTurn = true;
        transform.position = player.position;
        transform.rotation = player.rotation;
    }

    private void Update()
    {
        if (isTurn && MaceObject != null)
        {
            MaceObject.transform.RotateAround(player.position, Vector3.back, 800 * Time.deltaTime);
        }
    }
}

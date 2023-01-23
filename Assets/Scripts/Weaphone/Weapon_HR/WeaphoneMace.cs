using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaphoneMace : Weaphone
{
    public static Vector3 Direction;
    public Transform player;

    GameObject MaceObject;
    bool isTurn = false;

    //���� �̵����� Ȯ�� �Լ�
    void Direction_Check()
    {
        float Hor;
        float Ver;

        Hor = Player_Move.playerMove.Horizontal;
        Ver = Player_Move.playerMove.Vertical;

        //Ű���� �Է� üũ
        //ö���� ���� ������ �̵� ����� �޶�� �ϹǷ� 8�������� �� ĭ�� �Ʒ��� �δ�.
        if (Hor > 0)
        {
            if (Ver > 0) // ��� -> ��
            {
                Direction = new Vector3(0, 1f, 0);
            }
            else if (Ver < 0) // ���� -> ��
            {
                Direction = new Vector3(1f, 0f, 0);
            }
            else // �� -> ���
            {
                Direction = new Vector3(0.71f, 0.71f, 0);
            }
        }
        else if (Hor < 0)
        {
            if (Ver > 0) // �»� -> ��
            {
                Direction = new Vector3(-1f, 0f, 0);
            }
            else if (Ver < 0) // ���� -> ��
            {
                Direction = new Vector3(0f, -1f, 0);
            }
            else // �� -> ����
            {
                Direction = new Vector3(-0.71f, -0.71f, 0);
            }
        }
        else // x�� ����
        {
            if (Ver > 0) // �� -> �»�
            {
                Direction = new Vector3(-0.71f, 0.71f, 0);
            }
            else if (Ver < 0) // �� -> ����
            {
                Direction = new Vector3(0.71f, -0.71f, 0);
            }
            else  //����
            {
            }
        }
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        //����ü ����
        SetSpeed(200.0f);
        //���� ��ٿ�
        SetCoolDown(2.0f);
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

        //����ü ����
        MaceObject = Instantiate(projectile, transform);
        //����ü �θ� ������Ʈ ����
        MaceObject.transform.parent = null;
        MaceObject.SetActive(true);
        //����ü ���ӽð� ����
        MaceObject.GetComponent<Projectile>().SetDuration(0.5f);
        //����ü ���� �� �̵� ����
        MaceObject.GetComponent<Rigidbody>().AddTorque(new Vector3(0,0,1) * 300 * (-1));
        isTurn = true;
        transform.position = player.position;
        transform.rotation = player.rotation;
    }

    private void Update()
    {
        if (isTurn && MaceObject != null)
        {
            MaceObject.transform.RotateAround(player.position, Vector3.back, 200 * Time.deltaTime);
        }
    }
}

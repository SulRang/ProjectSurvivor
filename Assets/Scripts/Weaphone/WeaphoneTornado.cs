using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaphoneTornado : Weaphone
{
    /// <summary>
    /// ������ Ÿ������ ����ü�� ��ȯ�ϴ� ����
    /// </summary>

    [SerializeField]
    int level = 1;

    bool isUpgrade = false;

    [SerializeField]
    GameObject Shoes;

    protected override void Start()
    {
        base.Start();
        //����ü ����
        SetProjectileNum(1);
        //����ü �ӵ�. ���׷��̵� ���� ����.
        SetSpeed(300.0f);
        //���� ��ٿ�
        SetCoolDown(1.0f);
    }

    public override void Attack()
    {
        //������ Ÿ�� Transform ��������
        Transform target = transform.parent.GetComponent<WeaphoneCenter>().GetRandomTarget();
        if (projectile == null)
            return;
        if (target == null)
            return;
        //Ÿ�� vector ��� (y 1�� ���ؾ� Ÿ���� ���)
        Vector3 targetPos = target.position + new Vector3(0, 1, 0);

        //����ü ����
        GameObject ProjectileObject = Instantiate(projectile, target);
        //����ü �θ� ������Ʈ ����
        ProjectileObject.transform.parent = null;
        ProjectileObject.SetActive(true);

        //����ü ���� �ð� ����
        ProjectileObject.GetComponent<Projectile>().SetDuration(1.0f);

        Vector2 moveVec = new Vector2(0f, 0f);

        // ���׷��̵� �� ����̵� �̵����� ����
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

    // ��ä ���׷��̵�. ������ �Ź߰� ��ä ��� 5���� �̻�. �����Ǵ� ����̵��� ����(�����¿� ��)�ϰ� �̵�
    public void Upgrade()
    {
        if (Shoes.GetComponent<ACC_Shoes>().GetLevel() >= 5 && level >= 5)
        {
            isUpgrade = true;
        }
    }

    // ���� �̵����� ����
    Vector2 SetMoveVec()
    {
        int dir_Index = Random.Range(0, 4);
        Vector2 _moveVec = new Vector2();
        switch (dir_Index)
        {
            //��
            case 0:
                _moveVec = Vector2.up;
                break;

            //�Ʒ�
            case 1:
                _moveVec = Vector2.down;
                break;

            //������
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


public class Monster : MonoBehaviour
{
    [SerializeField]
    public GameObject EXP;

    [SerializeField]
    public MonsterData monsterData;

    [SerializeField]
    Transform playerPos;

    IObjectPool<Monster> objectPool;

    [SerializeField]
    Vector3 towardVector = new Vector3();

    float curHp;
    float iTime = 0.5f;
    bool isHit = false;

    void Start()
    {
        playerPos = GameObject.Find("Player").transform;
        Positioning();
        curHp = monsterData.hp;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPos.position, monsterData.moveSpeed*Time.deltaTime);
        ForwardCheck();
    }

    public void GetDamage(float damage, float power)
    {
        if (isHit)
            return;
        curHp -= damage;
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        gameObject.GetComponent<Rigidbody2D>().AddForce((transform.position - playerPos.position).normalized * power, ForceMode2D.Impulse); ;
        isHit = true;
        Invoke("OffHit", iTime);
        if (curHp <= 0)
        {
            ExpDrop();
            if (gameObject.name.Contains("Boss"))
            {
                Destroy(gameObject);
                return;
            }
            DestroyMonster();
            ScoreSystem.score += monsterData.score;
        }
    }

    void OffHit()
    {
        isHit = false;
    }

    // ������Ʈ Ǯ�� ���޹���
    public void SetManagedPool(IObjectPool<Monster> _objectPool)
    {
        objectPool = _objectPool;
    }

    //������Ʈ ��Ȱ��ȭ
    public void DestroyMonster()
    {
        Positioning();
        objectPool.Release(this);
        curHp = monsterData.hp;
    }

    public void ExpDrop()
    {
        Instantiate(EXP, gameObject.transform.position, gameObject.transform.rotation);
    }

    public void RePositinon(int _index, GameObject _opposite)
    {
        switch (_index)
        {
            //�� ����
            case 0:
                this.gameObject.transform.position = new Vector2(transform.position.x + Random.Range(-5f, 5f), _opposite.transform.position.y + 7f);
                break;

            //�Ʒ� ����
            case 1:
                this.gameObject.transform.position = new Vector2(transform.position.x + Random.Range(-5f, 5f), _opposite.transform.position.y - 10f);
                break;
            // ���� ����
            case 2:
                this.gameObject.transform.position = new Vector2(_opposite.transform.position.x - 5f, transform.position.y + Random.Range(-5f, 5f));
                break;

            //������ ����
            case 3:
                this.gameObject.transform.position = new Vector2(_opposite.transform.position.x + 5f, transform.position.y + Random.Range(-5f, 5f));
                break;

            default:
                break;
        }
    }

    public Vector3 Positioning()
    {
        int _index = Random.Range(0, 4);
        switch (_index)
        {
            //��
            case 0:
                this.gameObject.transform.position = new Vector3(playerPos.position.x + Random.Range(-10f, 10f), playerPos.position.y + 14f, 0f);
                break;

            //�Ʒ�
            case 1:
                this.gameObject.transform.position = new Vector3(playerPos.position.x + Random.Range(-10f, 10f), playerPos.position.y - 14f, 0f);
                break;

            // ����
            case 2:
                this.gameObject.transform.position = new Vector3(playerPos.position.x - 20f, playerPos.position.y + Random.Range(-15f, 15f), 0f);
                break;

            //������
            case 3:
                this.gameObject.transform.position = new Vector3(playerPos.position.x + 20f, playerPos.position.y + Random.Range(-15f, 15f), 0f);
                break;

            default:
                break;
        }

        return this.gameObject.transform.position;
    }

    void ForwardCheck()
    {
        towardVector = playerPos.position - transform.position;

        if (towardVector.x <= 0)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, -1);
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 1);
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }
    }
}

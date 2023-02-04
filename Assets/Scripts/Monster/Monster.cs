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

    int curHp;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.Find("Player").transform;
        curHp = monsterData.hp;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPos.position, monsterData.moveSpeed*Time.deltaTime);
    }

    public void ReadyDestroy()
    {
        Invoke("DestroyMonster", 10f);
    }

    public void GetDamage(int damage)
    {
        //Debug.Log(curHp);
        curHp -= damage;
        if (curHp <= 0)
        {
            ExpDrop();
            DestroyMonster();
        }
    }

    // ������Ʈ Ǯ�� ���޹���
    public void SetManagedPool(IObjectPool<Monster> _objectPool)
    {
        objectPool = _objectPool;
    }

    //������Ʈ ��Ȱ��ȭ
    public void DestroyMonster()
    {
        objectPool.Release(this);
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
                this.gameObject.transform.position = new Vector2(transform.position.x + Random.Range(-5f, 5f), _opposite.transform.position.y + 5f);
                break;

            //�Ʒ� ����
            case 1:
                this.gameObject.transform.position = new Vector2(transform.position.x + Random.Range(-5f, 5f), _opposite.transform.position.y - 5f);
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

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


public class Monster : MonoBehaviour
{
    [SerializeField]
    public MonsterData monsterData;

    [SerializeField]
    Transform playerPos;

    IObjectPool<Monster> objectPool;
    
    // Start is called before the first frame update
    void Start()
    {
        playerPos = FindObjectOfType<PlayerController>().transform;
        int a = Random.Range(0, 11);
        Invoke("DestroyMonster", a);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPos.position, monsterData.moveSpeed*Time.deltaTime);
    }

    public void ReadyDestroy()
    {
        Invoke("DestroyMonster", 5f);
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

    public void RePositinon(int _index)
    {
        switch (_index)
        {
            //��
            case 0:
                this.gameObject.transform.position = new Vector2(transform.position.x, playerPos.position.y - 10f);
                break;

            //�Ʒ�
            case 1:
                this.gameObject.transform.position = new Vector2(transform.position.x, playerPos.position.y + 10f);
                break;
            //������
            case 2:
                this.gameObject.transform.position = new Vector2(playerPos.position.x + 15f, transform.position.y);
                break;

            //����
            case 3:
                this.gameObject.transform.position = new Vector2(playerPos.position.x - 15f, transform.position.y);
                break;

            default:
                break;
        }
    }

}

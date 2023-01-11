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
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPos.position, monsterData.moveSpeed*Time.deltaTime);
    }

    public void MonsterInfo()
    {
        Debug.Log("�����Ϸ�");
        Invoke("DestroyMonster", 5f);
    }

    // ������Ʈ Ǯ�� ���޹���
    public void SetManagedPool(IObjectPool<Monster> _objectPool)
    {
        objectPool = _objectPool;
    }

    public void DestroyMonster()
    {
        objectPool.Release(this);
    }


}

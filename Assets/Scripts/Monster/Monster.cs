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
        Debug.Log("생성완료");
        Invoke("DestroyMonster", 5f);
    }

    // 오브젝트 풀을 전달받음
    public void SetManagedPool(IObjectPool<Monster> _objectPool)
    {
        objectPool = _objectPool;
    }

    public void DestroyMonster()
    {
        objectPool.Release(this);
    }


}

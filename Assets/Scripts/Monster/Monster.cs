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

    // 오브젝트 풀을 전달받음
    public void SetManagedPool(IObjectPool<Monster> _objectPool)
    {
        objectPool = _objectPool;
    }

    //오브젝트 비활성화
    public void DestroyMonster()
    {
        objectPool.Release(this);
    }

    public void RePositinon(int _index)
    {
        switch (_index)
        {
            //위
            case 0:
                this.gameObject.transform.position = new Vector2(transform.position.x, playerPos.position.y - 10f);
                break;

            //아래
            case 1:
                this.gameObject.transform.position = new Vector2(transform.position.x, playerPos.position.y + 10f);
                break;
            //오른쪽
            case 2:
                this.gameObject.transform.position = new Vector2(playerPos.position.x + 15f, transform.position.y);
                break;

            //왼쪽
            case 3:
                this.gameObject.transform.position = new Vector2(playerPos.position.x - 15f, transform.position.y);
                break;

            default:
                break;
        }
    }

}

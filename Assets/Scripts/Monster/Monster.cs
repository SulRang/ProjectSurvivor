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

    float curHp;
    float iTime = 0.5f;
    bool isHit = false;

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

    public void GetDamage(float damage)
    {
        //Debug.Log(curHp);
        if (isHit)
            return;
        curHp -= damage;
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

    // 오브젝트 풀을 전달받음
    public void SetManagedPool(IObjectPool<Monster> _objectPool)
    {
        objectPool = _objectPool;
    }

    //오브젝트 비활성화
    public void DestroyMonster()
    {
        Positioning();
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
            //위 접촉
            case 0:
                this.gameObject.transform.position = new Vector2(transform.position.x + Random.Range(-5f, 5f), _opposite.transform.position.y + 7f);
                break;

            //아래 접촉
            case 1:
                this.gameObject.transform.position = new Vector2(transform.position.x + Random.Range(-5f, 5f), _opposite.transform.position.y - 10f);
                break;
            // 왼쪽 접촉
            case 2:
                this.gameObject.transform.position = new Vector2(_opposite.transform.position.x - 5f, transform.position.y + Random.Range(-5f, 5f));
                break;

            //오른쪽 접촉
            case 3:
                this.gameObject.transform.position = new Vector2(_opposite.transform.position.x + 5f, transform.position.y + Random.Range(-5f, 5f));
                break;

            default:
                break;
        }
    }

    public void Positioning()
    {
        int _index = Random.Range(0, 4);
        switch (_index)
        {
            //위
            case 0:
                this.gameObject.transform.position = new Vector3(playerPos.position.x + Random.Range(-10f, 10f), playerPos.position.y + 14f, 0f);
                break;

            //아래
            case 1:
                this.gameObject.transform.position = new Vector3(playerPos.position.x + Random.Range(-10f, 10f), playerPos.position.y - 14f, 0f);
                break;

            // 왼쪽
            case 2:
                this.gameObject.transform.position = new Vector3(playerPos.position.x - 20f, playerPos.position.y + Random.Range(-15f, 15f), 0f);
                break;

            //오른쪽
            case 3:
                this.gameObject.transform.position = new Vector3(playerPos.position.x + 20f, playerPos.position.y + Random.Range(-15f, 15f), 0f);
                break;

            default:
                break;
        }
    }

}

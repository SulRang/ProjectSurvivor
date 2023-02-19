using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SampleSpawner : MonoBehaviour
{
    [SerializeField]
    List<MonsterData> monsterDataList;

    [SerializeField]
    MonsterData curMonster;

    [SerializeField]
    GameObject monsterPrefab;

    [SerializeField]
    IObjectPool<Monster> pool;

    [SerializeField]
    float cooltime = 1.5f;

    [SerializeField]
    public GameObject[] triggers;

    [SerializeField]
    int monster_Num = 0;

    // 최대 몬스터 스폰 수. 기본 40마리
    [SerializeField]
    int maximum = 40;

    private void Awake()
    {
        pool = new ObjectPool<Monster>(CreateMonster, GetMonster, ReleaseMonster, DestroyMonster, maxSize:maximum);
    }

    void Start()
    {
        monsterPrefab = curMonster.prefab;
        StartCoroutine(SpawnCoroutine());
    }

    public void Spawn()
    {
        var monster = pool.Get();
        monster.GetComponent<Monster>().monsterData = curMonster;
        ++monster_Num;
    }

    // 몹 생성 코루틴
    IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(cooltime); // 쿨타임 기본 1.5초


        if (monster_Num < maximum)
        {
            Spawn();
        }

        StartCoroutine(SpawnCoroutine()); // 정해진 시간마다 생성
    }

    // 오브젝트 생성
    Monster CreateMonster()
    {        
        Monster monster;
        monster = Instantiate(monsterPrefab, transform.position, Quaternion.identity).GetComponent<Monster>();
        monster.SetManagedPool(pool);
        return monster;
    }

    // 풀로부터 오브젝트를 가져옴
    void GetMonster(Monster monster)
    {
        monster.gameObject.SetActive(true);
    }

    // 풀에 오브젝트를 반환
    void ReleaseMonster(Monster monster)
    {
        monster.gameObject.SetActive(false);
        --monster_Num;
    }

    //풀에서 오브젝트를 파괴
    void DestroyMonster(Monster monster)
    {
        Destroy(monster.gameObject);
    }

    public void SetMonsterData(MonsterData _monsterData)
    {
        curMonster = _monsterData;
    }

    public void SetMaximum(int _maximum)
    {
        maximum = _maximum;
    }

    public void SetCooltime(float _cooltime)
    {
        cooltime = _cooltime;
    }

    public void SetMonsterHp(int _hp)
    {
        curMonster.hp = _hp;
    }
}
